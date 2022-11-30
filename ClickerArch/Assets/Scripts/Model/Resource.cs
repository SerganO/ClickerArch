using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    [System.Serializable]
    public enum Rarity
    {
        Common, Rare, Epic, Legendary
    }

    public Rarity rarity;
    public int count = 0;
}
