using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    public Image Icon;
    public Text NameLabel;

    public Button ActionButton;

    public void Setup(Sprite sprite, string text)
    {
        Icon.sprite = sprite;
        NameLabel.text = text;
    }

    public void SetupAsClothes(string heroId)
    {
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Heroes/" + heroId + "/Preview");
        var name = heroId;

        Setup(sprite, name);

        ActionButton.onClick.RemoveAllListeners();
        ActionButton.onClick.AddListener(()=>{ Services.GetInstance().GetPlayer().CurrentHeroId = heroId; });
    }
}
