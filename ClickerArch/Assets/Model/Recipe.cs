using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public ItemCategory Category = ItemCategory.Thing;
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
}
