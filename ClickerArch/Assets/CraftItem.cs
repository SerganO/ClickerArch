using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    public Transform ResourcesTransform;
    public DetailElement Element;
    public Button ActionButton;
    public Button InfoButton;

    public Image Icon;
    public Text Text;


    public void SetupForRecipe(Recipe recipe)
    {
        Helper.ClearTransform(ResourcesTransform);

        recipe.RequiredItems.ForEach(i =>
        {
            var el = Instantiate(Element, ResourcesTransform);
            el.SetupForItem(i);
        });

        recipe.RequiredResources.ForEach(res =>
        {
            var el = Instantiate(Element, ResourcesTransform);
            el.SetupForResource(res);
        });

        if (recipe.RequiredGold != 0)
        {
            var goldEl = Instantiate(Element, ResourcesTransform);
            goldEl.SetupForGold(recipe.RequiredGold);
        }

        if (recipe.ResultItem != null && !recipe.ResultItem.IsEmpty())
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + recipe.ResultItem.id);
            //Text.text = recipe.ResultItem.name;

        }
        else if (recipe.ResultResource != null && recipe.ResultResource.count > 0)
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + recipe.ResultResource.rarity);
            //Text.text = recipe.ResultResource.rarity.ToString();
        }
        else
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Coin/Coin");
            //Text.text = ((int)recipe.ResultGold).ToString();
        }
        
        Text.text = recipe.Name;
        if (recipe.count > 1) Text.text += " x" + recipe.count;
    }

    public void SetupForSkill(HeroParameter parameter)
    {
        Helper.ClearTransform(ResourcesTransform);


        var goldEl = Instantiate(Element, ResourcesTransform);
        var newLevel = Services.GetInstance().GetPlayer().LevelForParameter(parameter) + 1;
        goldEl.SetupForGold(Services.GetInstance().GetDataService().CostForParameterForLevel(parameter, newLevel));

        Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Modificators/" + parameter);
        var player = Services.GetInstance().GetPlayer();
        var level = player.LevelForParameter(parameter);
        var dataService = Services.GetInstance().GetDataService();
        string description = "+" + string.Format("{0:0.###}", dataService.ValueForParameterForLevel(parameter, level + 1) - dataService.ValueForParameterForLevel(parameter, level));

        Text.text = parameter.ToString() + " " + newLevel + ": " + description;
    }


    public void SetupAsClothes(string heroId, VoidFunc completion)
    {
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Heroes/" + heroId + "/Preview");
        var name = heroId;
        var goldEl = Instantiate(Element, ResourcesTransform);
        goldEl.SetupForGold(Services.GetInstance().GetDataService().CostForClothes(heroId));
        Setup(sprite, name);

        ActionButton.onClick.RemoveAllListeners();
        ActionButton.onClick.AddListener(() =>
        {
            var cost = Services.GetInstance().GetDataService().CostForClothes(heroId);
            Services.GetInstance().GetPlayer().Purchase(cost);
            Services.GetInstance().GetPlayer().availableHeroes.Add(heroId);
            completion();
        });

    }

    public void Setup(Sprite sprite, string text)
    {
        Icon.sprite = sprite;
        Text.text = text;
    }
}
