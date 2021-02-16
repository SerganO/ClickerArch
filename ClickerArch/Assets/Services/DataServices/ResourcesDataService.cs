using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDataService : IDataService
{
    public AudioClip GetAudioClipForID(string id)
    {
        return Resources.Load("AudioClips/" + id) as AudioClip;
    }

    public Sprite GetSpriteForID(string id)
    {
        return Resources.Load("Sprites/" + id) as Sprite;
    }
}
