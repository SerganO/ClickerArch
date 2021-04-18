using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory
{
    Thing,
    Clothes,
    Weapon,
    Transport,
    Skill
}

public class Item
{
    public string id = "";
    public string name = "";
    public int count = 0;

    public List<Modificator> modificators = new List<Modificator>();
    public ItemCategory Category = ItemCategory.Thing;
    

}
