using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemScript : MonoBehaviour
{
    public Image Icon;
    public Text NameLabel;
    public Button InfoButton;

    public Button ActionButton;

    public void Setup(Sprite sprite, string text)
    {
        Icon.sprite = sprite;
        NameLabel.text = text;
    }

    public void SetupAsClothes(string heroId, VoidFunc completion)
    {
        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("Heroes/" + heroId + "/Preview");
        var name = heroId;

        Setup(sprite, name);

        ActionButton.onClick.RemoveAllListeners();
        ActionButton.onClick.AddListener(()=>
        {
            Services.GetInstance().GetPlayer().SetHeroId(heroId);
            completion();
        });

    }

    public void SetupForSkill(HeroParameter parameter)
    {
        var newLevel = Services.GetInstance().GetPlayer().LevelForParameter(parameter);

        var sprite = Services.GetInstance().GetDataService().GetSpriteForID("UI/Modificators/" + parameter);

        var text = parameter.ToString() + " " + newLevel;

        Setup(sprite, text);
    }
}
