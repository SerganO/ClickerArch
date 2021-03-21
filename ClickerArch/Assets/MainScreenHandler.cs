using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenHandler : MonoBehaviour
{
    public SceneLoader Loader;

    public void Load()
    {
        Loader.Load(SceneLoader.Scene.Level);
    }

}
