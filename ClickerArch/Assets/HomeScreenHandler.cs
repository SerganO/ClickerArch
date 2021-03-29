using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public string BackgroundClipName;
    AudioClip BackgroundClip;
    
    private void Start()
    {
        BackgroundClip = Services.GetInstance().GetDataService().GetAudioClipForID(BackgroundClipName);
        Debug.Log(BackgroundClip);
        MusicManager.instance.Play(BackgroundClip);
    }

    private void Update()
    {

    }

    public void Load()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }
}
