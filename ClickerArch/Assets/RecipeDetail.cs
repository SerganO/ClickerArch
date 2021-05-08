using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeDetail : MonoBehaviour
{
    public Transform Modificators;
    public Transform Resources;
    public DetailElement Element;

    public Image Icon;
    public Text Text;
    public Text DescriptionText;

    public Button AcceptButton;
    public Button DisagreeButton;

    public ContentSizeFitter BackgroundPanel;

    public event VoidFunc OnAccept;

    void Start()
    {
        DisagreeButton.onClick.AddListener(() => Hide());
    }

    Recipe _recipe;
    HeroParameter _parameter;

    public void ShowDetailForParameter(HeroParameter parameter, bool isUpgrade = true)
    {
        _parameter = parameter;

        Helper.ClearTransform(Modificators);
        Helper.ClearTransform(Resources);


        AcceptButton.onClick.RemoveAllListeners();


        if(isUpgrade)
        {
            AcceptButton.onClick.AddListener(() => AcceptUpgrade());
            AcceptButton.interactable = Services.GetInstance().GetDataService().CanUpgradeParameter(parameter);




            var goldEl = Instantiate(Element, Resources);
            var newLevel = Services.GetInstance().GetPlayer().LevelForParameter(parameter) + 1;
            goldEl.SetupForGold(Services.GetInstance().GetDataService().CostForParameterForLevel(parameter, newLevel));

            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Modificators/" + parameter);

            Text.text = parameter.ToString() + " " + newLevel;

            DescriptionText.text = LocalizationManager.GetDescriptionForParameter(parameter);
        } else
        {
            AcceptButton.onClick.AddListener(() => Hide());
            AcceptButton.interactable = true;




           
            var newLevel = Services.GetInstance().GetPlayer().LevelForParameter(parameter);

            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Modificators/" + parameter);

            Text.text = parameter.ToString() + " " + newLevel;

            DescriptionText.text = LocalizationManager.GetDescriptionForParameter(parameter, false);
        }
        


        BackgroundPanel.SetLayoutVertical();
    }

    public void ShowDetailForRecipe(Recipe recipe)
    {
        AcceptButton.onClick.RemoveAllListeners();
        AcceptButton.onClick.AddListener(() => AcceptCraft());
        _recipe = recipe;
        DescriptionText.text = recipe.Description;
        AcceptButton.interactable = CraftMaster.CanCraft(recipe);

        Helper.ClearTransform(Modificators);
        Helper.ClearTransform(Resources);

        if (recipe.ResultItem != null)
        {
            recipe.ResultItem.modificators.ForEach(mod =>
            {
                mod.values.ForEach(val =>
                {
                    var el = Instantiate(Element, Modificators);
                    el.SetupForModificatorValue(mod, val);
                });

            });
        }



        recipe.RequiredItems.ForEach(i =>
        {
            var el = Instantiate(Element, Resources);
            el.SetupForItem(i);
        });

        recipe.RequiredResources.ForEach(res =>
        {
            var el = Instantiate(Element, Resources);
            el.SetupForResource(res);
        });

        if (recipe.RequiredGold != 0)
        {
            var goldEl = Instantiate(Element, Resources);
            goldEl.SetupForGold(recipe.RequiredGold);
        }

        if (recipe.ResultItem != null)
        {

            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + recipe.ResultItem.id);
            //Text.text = recipe.ResultItem.name;

        }
        else if (recipe.ResultResource != null)
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + recipe.ResultResource.rarity);
            //Text.text = recipe.ResultResource.rarity.ToString();
        }
        else
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Coin/Coin");
            //Text.text = ((int)recipe.ResultGold).ToString();
        }

        Text.text = recipe.name;

        BackgroundPanel.SetLayoutVertical();

    }

    public void Setup(Sprite sprite, string text)
    {
        Icon.sprite = sprite;
        Text.text = text;
    }

    public void ShowDetailForHero(string heroId, VoidFunc completion)
    {
        AcceptButton.onClick.RemoveAllListeners();
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Heroes/" + heroId + "/Preview");
        var name = heroId;

        Setup(sprite, name);

        Helper.ClearTransform(Modificators);
        Helper.ClearTransform(Resources);

        DescriptionText.text = LocalizationManager.GetDescriptionForHeroId(heroId);
        BackgroundPanel.SetLayoutVertical();

        AcceptButton.onClick.RemoveAllListeners();
        AcceptButton.onClick.AddListener(() => { Services.GetInstance().GetPlayer().SetHeroId(heroId); Hide(); completion(); });

    }

    public void ShowDetailForItem(Item item, VoidFunc completion)
    {
        AcceptButton.onClick.RemoveAllListeners();
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + item.id);
        var name = item.name;

        Setup(sprite, name);

        Helper.ClearTransform(Modificators);
        Helper.ClearTransform(Resources);

        DescriptionText.text = LocalizationManager.GetDescriptionForItemId(item.id);

        item.modificators.ForEach(mod =>
        {
            mod.values.ForEach(val =>
            {
                var el = Instantiate(Element, Modificators);
                el.SetupForModificatorValue(mod, val);
            });

        });
        BackgroundPanel.SetLayoutVertical();

        AcceptButton.onClick.RemoveAllListeners();
        AcceptButton.onClick.AddListener(() =>
        {
            Hide(); completion();
        });
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void AcceptCraft()
    {
        CraftMaster.Craft(_recipe);
        OnAccept?.Invoke();
        Hide();
    }

    public void AcceptUpgrade()
    {

        var newLevel = Services.GetInstance().GetPlayer().LevelForParameter(_parameter) + 1;
        Services.GetInstance().GetPlayer().Purchase(Services.GetInstance().GetDataService().CostForParameterForLevel(_parameter, newLevel));
        Services.GetInstance().GetPlayer().UpgradeParameter(_parameter);
        OnAccept?.Invoke();
        Hide();
    }

    private void Update()
    {

    }

}
