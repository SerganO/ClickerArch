using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public InventoryUI UI;

    private void Start()
    {
        UI.UpdateUI();
    }

    public void LoadMain()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }

    public void SwitchToClothes()
    {
        UI.SwitchToClothes();
    }
}
