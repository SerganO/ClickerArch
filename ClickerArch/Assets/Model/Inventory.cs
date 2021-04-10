using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Resource> Resources = new List<Resource>();
    List<Item> Items = new List<Item>();

    public int CommonResourcesCount
    {
        get
        {
            return ResourcesCountForRarity(Resource.Rarity.Common);
        }
    }

    public int ResourcesCountForRarity(Resource.Rarity rarity)
    {
        var res = Resources.Find(r => r.rarity == rarity);
        if (res != null)
        {
            return res.count;
        }
        else
        {
            Resources.Add(new Resource { rarity = rarity, count = 0 });
            return 0;
        }
    }

    public void AddResource(Resource resource)
    {
        var res = Resources.Find(r => r.rarity == resource.rarity);
        if (res != null)
        {
            res.count += resource.count;
        } else
        {
            Resources.Add(resource);
        }
    }

    public void AddResources(List<Resource> resources)
    {
        resources.ForEach(r => AddResource(r));
    }

    public void AddItem(Item Item)
    {
        var res = Items.Find(i => i.id == Item.id);
        if (res != null)
        {
            res.count += Item.count;
        }
        else
        {
            Items.Add(Item);
        }
    }

    public void AddItems(List<Item> Items)
    {
        Items.ForEach(r => AddItem(r));
    }

}
