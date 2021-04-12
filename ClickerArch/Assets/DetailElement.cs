using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailElement : MonoBehaviour
{
    public Image Icon;
    public Text Text;

    public void Setup(Sprite sprite, string text)
    {
        Icon.sprite = sprite;
        Text.text = text;
    }

    public void SetupForItem(Item item)
    {
        Sprite sprite = null;
        var count = item.count;
        Setup(sprite, count.ToString());
    }

    public void SetupForResource(Resource resource)
    {
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Resource/" + resource.rarity);
        var count = resource.count;
        Setup(sprite, count.ToString());
    }

    public void SetupForModificatorValue(Modificator Parameter, Modificator.ChangeValue change)
    {
        var addPart = "";
        var finalPart = "";
        var value = change.value;

        switch (change.changeType)
        {
            case Modificator.ChangeValue.ValueChangeType.Const:
                finalPart = "";
                break;
            case Modificator.ChangeValue.ValueChangeType.Coef:
                value *= 100;
                finalPart = "%";
                break;
        }

        addPart = value >= 0 ? "+" : "";
        Setup(null, addPart + ((int)value).ToString() + finalPart);
        
    }

    public void SetupForGold(double gold)
    {
        Sprite sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Coin/Coin");
        Setup(sprite, ((int)gold).ToString());
    }

    public void SetupForXP(double XP)
    {
        Setup(null, ((int)XP).ToString());
    }
}
