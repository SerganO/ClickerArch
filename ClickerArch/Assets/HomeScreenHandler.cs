using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreenHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public void Load()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }
}
