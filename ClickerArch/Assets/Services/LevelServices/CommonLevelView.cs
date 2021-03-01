using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonLevelView : ILevelView
{
    public string ID { get; set; }

    public CommonLevelView(string id)
    {
        ID = id;
    }

    public Sprite GetBackgroundImage()
    {
        return Services.GetInstance().GetDataService().GetSpriteForID("Levels/" + ID);
    }

    public AudioClip GetBackgroundMusic()
    {
        return Services.GetInstance().GetDataService().GetAudioClipForID("Levels/" + ID);
    }

}
