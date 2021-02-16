using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
    AudioClip GetAudioClipForID(string id);
    Sprite GetSpriteForID(string id); 
}
