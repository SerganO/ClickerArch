using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Resource> Resources = new List<Resource>() { };

    List<Item> items = new List<Item>();
    
    public List<Item> Items
    {
        get
        {
            items.RemoveAll(item => item.id == "" || item.count == 0);
            return items;
        }
    }

    public List<Recipe> Recipes = new List<Recipe>();

    public Resource FindResourceForRarity(Resource.Rarity rarity)
    {
        var res = Resources.Find(r => r.rarity == rarity);
        if(res == null)
        {
            var newRes = new Resource { rarity = rarity, count = 0 };
            Resources.Add(newRes);
            return newRes;
        }
        return res;
    }

    public Item FindItemForID(string ID)
    {
        return Items.Find(item=> item.id == ID);
    }

    public Recipe FindRecipeForID(string ID)
    {
        return Recipes.Find(recipe => recipe.id == ID);
    }

    public int ResourcesCountForRarity(Resource.Rarity rarity)
    {
        return FindResourceForRarity(rarity).count;
    }

    public void AddResource(Resource resource)
    {
        FindResourceForRarity(resource.rarity).count += resource.count;
    }

    public void AddResources(List<Resource> resources)
    {
        resources.ForEach(r => AddResource(r));
    }

    public bool CanRemoveResource(Resource resource)
    {
        return ResourcesCountForRarity(resource.rarity) >= resource.count;
    }

    public bool RemoveResource(Resource resource)
    {
        if (!CanRemoveResource(resource)) return false;
        removeResource(resource);
        return true;
    }

    void removeResource(Resource resource)
    {
        FindResourceForRarity(resource.rarity).count -= resource.count;
    }

    public bool RemoveResources(List<Resource> resources)
    {
        if(resources.TrueForAll(r=> { return CanRemoveResource(r); }))
        {
            resources.ForEach(r => removeResource(r));
            return true;
        }

        return false;
    }

    public void AddItem(Item newItem)
    {
        var item = FindItemForID(newItem.id);
        if (item != null)
        {
            item.count += newItem.count;
        }
        else
        {
            items.Add((Item)newItem.Clone());
        }
    }

    public void AddItems(List<Item> Items)
    {
        Items.ForEach(r => AddItem(r));
    }

    public void AddRecipe(Recipe recipe)
    {
        var item = FindRecipeForID(recipe.id);
        if (item != null)
        {
            item.count += recipe.count;
        }
        else
        {
            Recipes.Add(recipe);
        }
    }

    public void AddRecipes(List<Recipe> recipes)
    {
        recipes.ForEach(r => AddRecipe(r));
    }

    public bool CanRemoveItem(Item Item)
    {
        var item = FindItemForID(Item.id);

        return  item != null && item.count >= Item.count;
    }

    public bool RemoveItem(Item Item)
    {
        if (!CanRemoveItem(Item)) return false;
        removeItem(Item);
        return true;
    }

    void removeItem(Item Item)
    {
        var item = FindItemForID(Item.id);
        item.count -= Item.count;
        if (item.count <= 0) Items.Remove(item);
    }

    public bool RemoveItems(List<Item> Items)
    {
        if (Items.TrueForAll(r => { return CanRemoveItem(r); }))
        {
            Items.ForEach(r => removeItem(r));
            return true;
        }

        return false;
    }
}
