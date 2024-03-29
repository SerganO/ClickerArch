﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe: System.ICloneable
{
    public int count = 0;
    public ItemCategory Category = ItemCategory.Thing;
    public Resource.Rarity rarity = Resource.Rarity.Common;
    public string id = "";
    public string name = "";

    public double RequiredGold = 0;
    public int RequiredLevel = 0;
    public List<Resource> RequiredResources = new List<Resource>();
    public List<Item> RequiredItems = new List<Item>();

    public double ResultGold = 0;
    public double ResultXP = 0;
    public Resource ResultResource;
    public Item ResultItem;

    public bool IsPermanent = false;

    ItemData itemData
    {
        get
        {
            return LocalizationManager.GetDataForItemId(id);
        }
    }

    public string Description
    {
        get
        {
            return itemData.description;
        }
    }

    public string Name
    {
        get
        {
            return itemData.name;
        }
    }


    public object Clone()
    {
        var value = JsonUtility.ToJson(this);
        return (Recipe)JsonUtility.FromJson(value, typeof(Recipe));
    }
}
