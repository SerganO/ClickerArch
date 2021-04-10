using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesPanel : MonoBehaviour
{
    public ResourceItem CommonResource;
    public ResourceItem RareResource;
    public ResourceItem EpicResource;
    public ResourceItem LegendaryResource;


    public void UpdateUI()
    {
        CommonResource.SetupForRarity(Resource.Rarity.Common);
        RareResource.SetupForRarity(Resource.Rarity.Rare);
        EpicResource.SetupForRarity(Resource.Rarity.Epic);
        LegendaryResource.SetupForRarity(Resource.Rarity.Legendary);
    }

}
