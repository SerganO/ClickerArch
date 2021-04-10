using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public MoneyPanel MoneyPanel;

    private void Start()
    {
        MoneyPanel.UpdateUI();
    }

    public void LoadMain()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }
}
