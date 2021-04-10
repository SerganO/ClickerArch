using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    public string id = "";

    public double RequiredGold = 0;
    public double RequiredXP = 0;
    public List<Resource> RequiredResources = new List<Resource>();
    public List<Item> RequiredItems = new List<Item>();

    public double ResultGold = 0;
    public double ResultXP = 0;
    public List<Resource> ResultResources = new List<Resource>();
    public List<Item> ResultItems = new List<Item>();
}
