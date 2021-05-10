using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemCategory
{
    Thing,
    Clothes,
    Weapon,
    Transport,
    Skill
}


[System.Serializable]
public class Item
{
    public string id;
    public string name;
    public int count;

    public List<Modificator> modificators;// = new List<Modificator>();
    public ItemCategory Category;// = ItemCategory.Thing;

    public Item()
    {
        id = "";
        name = "";
        count = 0;
        modificators = new List<Modificator>();
        Category = ItemCategory.Thing;
    }

    public Item(string id, string name, int count, List<Modificator> modificators, ItemCategory Category)
    {
        this.id = id;
        this.name = name;
        this.count = count;
        this.modificators = modificators;
        this.Category = Category;
    }

    public bool IsEmpty()
    {
        return id == "" &&
        name == "" &&
        count == 0 &&
        modificators.Count == 0 &&
        Category == ItemCategory.Thing;
    }

    public override string ToString()
    {
        return id + " " +
        name + " " +
        count + " " +
        modificators.Count + " " +
        Category + " " + IsEmpty();
    }
}
