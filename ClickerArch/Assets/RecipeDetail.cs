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

    public Button AcceptButton;

    public event VoidFunc OnCraft;

    void Start()
    {
    }

    Recipe _recipe;

    public void ShowDetailForRecipe(Recipe recipe)
    {
        _recipe = recipe;

        AcceptButton.interactable = CraftMaster.CanCraft(recipe);

        Helper.ClearTransform(Modificators);
        Helper.ClearTransform(Resources);

        if(recipe.ResultItem != null)
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

        if(recipe.ResultItem != null)
        {
            Icon.sprite = null;
            Text.text = recipe.ResultItem.name;

        } else if(recipe.ResultResource != null)
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + recipe.ResultResource.rarity);
            Text.text = recipe.ResultResource.rarity.ToString();
        } else
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Coin/Coin");
            Text.text = ((int)recipe.ResultGold).ToString();
        }

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void AcceptCraft()
    {
        CraftMaster.Craft(_recipe);
        OnCraft?.Invoke();
        Hide();
    }


}
