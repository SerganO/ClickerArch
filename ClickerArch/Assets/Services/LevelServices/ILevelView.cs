using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelView
{
    string ID { get; set; }
    Sprite GetBackgroundImage();
    AudioClip GetBackgroundMusic();
}
