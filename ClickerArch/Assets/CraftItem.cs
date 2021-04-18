﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    public Transform ResourcesTransform;
    public ResourceItem ResourceItem;
    public Button ActionButton;
    public Button InfoButton;

    public Image Icon;
    public Text Text;


    public void SetupForRecipe(Recipe recipe)
    {
        Helper.ClearTransform(ResourcesTransform);

        recipe.RequiredItems.ForEach(i =>
        {
            var el = Instantiate(ResourceItem, ResourcesTransform);
            el.SetupForItem(i);
        });

        recipe.RequiredResources.ForEach(res =>
        {
            var el = Instantiate(ResourceItem, ResourcesTransform);
            el.SetupForResource(res);
        });

        if (recipe.RequiredGold != 0)
        {
            var goldEl = Instantiate(ResourceItem, ResourcesTransform);
            goldEl.SetupForGold(recipe.RequiredGold);
        }

        if (recipe.ResultItem != null)
        {
            Icon.sprite = null;
            Text.text = recipe.ResultItem.name;

        }
        else if (recipe.ResultResource != null)
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + recipe.ResultResource.rarity);
            Text.text = recipe.ResultResource.rarity.ToString();
        }
        else
        {
            Icon.sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Coin/Coin");
            Text.text = ((int)recipe.ResultGold).ToString();
        }
    }
}
