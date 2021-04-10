using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceItem : MonoBehaviour
{
    public Image Icon;
    public Text countLabel;


    public void Setup(Sprite sprite, string text)
    {
        Icon.sprite = sprite;
        countLabel.text = text;
    }

    public void SetupForRarity(Resource.Rarity rarity)
    {
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + rarity);
        var count = Services.GetInstance().GetPlayer().Inventory.ResourcesCountForRarity(rarity);
        Setup(sprite, count.ToString());
    }


}
