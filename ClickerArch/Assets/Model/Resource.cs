using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource
{
    public enum Rarity
    {
        Common, Rare, Epic, Legendary
    }

    public Rarity rarity;
    public int count = 0;
}
