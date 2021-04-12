using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string id = "";
    public string name = "";
    public int count = 0;

    public List<Modificator> modificators = new List<Modificator>();

    public enum Type
    {
        Thing,
        Clothes,
        Weapon,
        Transport,
        Skill
    }

}
