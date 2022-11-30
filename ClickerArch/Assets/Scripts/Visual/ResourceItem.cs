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

    public void SetupForResource(Resource resource)
    {
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + resource.rarity);
        var count = resource.count;
        Setup(sprite, count.ToString());
    }

    public void SetupForGold(double gold)
    {
        Sprite sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Coin/Coin");
        Setup(sprite, ((int)gold).ToString());
    }

    public void SetupForItem(Item item)
    {
        Sprite sprite = null;
        var count = item.count;
        Setup(sprite, count.ToString());
    }


}
