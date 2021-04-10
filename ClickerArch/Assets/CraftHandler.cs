using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public ResourcesPanel ResourcesPanel;
    public MoneyPanel MoneyPanel;


    private void Start()
    {
        ResourcesPanel.UpdateUI();
        MoneyPanel.UpdateUI();
    }

    public void LoadMain()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }



}
