using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop
{
    public double gold = 0;
    public double xpBaseLevel = 0;

    public List<DropResource> Resources = new List<DropResource>();
    public List<DropItem> Items = new List<DropItem>();
    public List<DropRecipe> Recipes = new List<DropRecipe>();

    public List<Resource> GetResourcesAfterProbability()
    {
        var resources = new List<Resource>();

        Resources.ForEach(resource => {
            if (ProbabilityMaster.Test(resource.probability)) resources.Add(resource.Resource);
        });

        return resources;
    }

    public List<Item> GetItemsAfterProbability()
    {
        var items = new List<Item>();

        Items.ForEach(item => {
            if (ProbabilityMaster.Test(item.probability)) items.Add(item.Item);
        });

        return items;
    }
}

public class DropResource
{
    public Resource Resource;
    public double probability;
}

public class DropItem
{
    public Item Item;
    public double probability;
}

public class DropRecipe
{
    public Recipe Recipe;
    public double probability;
}

public class ProbabilityMaster
{
    public static bool Test(double probability)
    {
        var res = Random.Range(0, 100);

        return probability > (100 - res);
    }

}
