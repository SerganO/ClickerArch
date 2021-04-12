using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMaster
{
    static public void Craft(Recipe recipe)
    {
        if (!CanCraft(recipe)) return;

        var player = Services.GetInstance().GetPlayer();
        player.Inventory.RemoveResources(recipe.RequiredResources);
        player.Inventory.RemoveItems(recipe.RequiredItems);
        player.Purchase(recipe.RequiredGold);

        if(recipe.ResultResource != null) player.Inventory.AddResource(recipe.ResultResource);
        if(recipe.ResultItem != null) player.Inventory.AddItem(recipe.ResultItem);
        player.AddGold(recipe.ResultGold);
        player.AddXP(recipe.ResultXP);

        if (!recipe.IsPermanent) player.Inventory.Recipes.Remove(recipe);
    }

    static public bool CanCraft(Recipe recipe)
    {
        var player = Services.GetInstance().GetPlayer();

        if (player.CoolLevel < recipe.RequiredLevel || player.Gold < recipe.RequiredGold) return false;

        return recipe.RequiredResources.TrueForAll(r =>
        {
            return player.Inventory.ResourcesCountForRarity(r.rarity) >= r.count;
        }) && recipe.RequiredItems.TrueForAll(i=>
        {
            var item = player.Inventory.FindItemForID(i.id);
            return item != null && item.count >= i.count;
        });
    }

}
