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

    public void UpdateForClothes()
    {
        UI.UpdateForClothes();
    }
    public void UpdateForThing()
    {
        UI.UpdateForThing();

    }

    public void UpdateForWeapon()
    {
        UI.UpdateForWeapon();

    }

    public void UpdateForTransport()
    {
        UI.UpdateForTransport();

    }

    public void UpdateForParameters()
    {
        UI.UpdateForParameters();

    }

}
