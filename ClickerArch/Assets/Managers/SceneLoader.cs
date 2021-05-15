using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static readonly string HomeScreenId = "HomeScreen";
    public static readonly string MainScreenId = "MainScreen";
    public static readonly string LevelScreenId = "LevelScreen";
    public static readonly string StoreScreenId = "GameStoreScreen";
    public static readonly string InventoryScreenId = "InventoryScreen";
    public static readonly string CraftScreenId = "CraftScreen";

    [System.Serializable]
    public enum Scene
    {
        Home, Main, Level, Store, Inventory, Craft
    }

    [System.Serializable]
    public enum BlockPanelType
    {
        transparent, image
    }

    public static string PrevSceneId;
    private string SceneId;

    public BlockPanelScript BlockPanel;
    public Image LoadBackImage;
    public Image LoadImage;
    public Text LoadText;

    private void Start()
    {
        BlockPanel.gameObject.SetActive(false);
        LoadBackImage.gameObject.SetActive(false);
        LoadImage.gameObject.SetActive(false);
        LoadText.gameObject.SetActive(false);
    }

    public void Load(string command)
    {
        var mainParts = command.Split('@');

        var parts = mainParts[0].Split('|');
        SceneId = parts[0];

        LoadBackImage.gameObject.SetActive(true);
        LoadImage.gameObject.SetActive(true);
        LoadText.gameObject.SetActive(true);

        if (mainParts.Length < 2)
        {
            BlockPanel.gameObject.SetActive(true);
        }
        else
        {
            switch (mainParts[1])
            {
                case "image":
                    BlockPanel.BackImage.color = new Color(255, 255, 255, 1);
                    BlockPanel.Logo.color = new Color(255, 255, 255, 1);
                    BlockPanel.gameObject.SetActive(true);
                    break;
                case "transparent":
                    var image = BlockPanel.BackImage;
                    image.color = new Color(0, 0, 0, 0);
                    BlockPanel.Logo.color = new Color(0, 0, 0, 0);
                    BlockPanel.gameObject.SetActive(true);
                    break;

            }
        }



        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }

    public void LoadWithTransparent(string sceneID)
    {
        SceneId = sceneID;

        var image = BlockPanel.BackImage;
        image.color = new Color(0, 0, 0, 0);
        BlockPanel.Logo.color = new Color(0, 0, 0, 0);
        BlockPanel.gameObject.SetActive(true);

        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }

    public void LoadWithImage(string sceneID)
    {
        SceneId = sceneID;


        BlockPanel.BackImage.color = new Color(255, 255, 255, 1);
        BlockPanel.Logo.color = new Color(255, 255, 255, 1);
        BlockPanel.gameObject.SetActive(true);


        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }

    public void LoadWithTransparent(Scene scene)
    {
        Load(scene, BlockPanelType.transparent);
    }

    public void LoadWithImage(Scene scene)
    {
        Load(scene, BlockPanelType.image);
    }

    public void Load(Scene scene, BlockPanelType blockPanelType = BlockPanelType.transparent)
    {
        switch (scene)
        {
            case Scene.Home:
                SceneId = HomeScreenId;
                break;
            case Scene.Main:
                SceneId = MainScreenId;
                break;
            case Scene.Level:
                SceneId = LevelScreenId;
                break;
            case Scene.Store:
                SceneId = StoreScreenId;
                break;
            case Scene.Inventory:
                SceneId = InventoryScreenId;
                break;
            case Scene.Craft:
                SceneId = CraftScreenId;
                break;
        }

        switch (blockPanelType)
        {
            case BlockPanelType.transparent:
                var image = BlockPanel.BackImage;
                image.color = new Color(0, 0, 0, 0);
                BlockPanel.Logo.color = new Color(0, 0, 0, 0);
                BlockPanel.gameObject.SetActive(true);
                break;
            case BlockPanelType.image:
                BlockPanel.BackImage.color = new Color(255, 255, 255, 1);
                BlockPanel.Logo.color = new Color(255, 255, 255, 1);
                BlockPanel.gameObject.SetActive(true);
                break;
        }

        Debug.Log("Load");
        StartCoroutine(AsyncLoad());
    }


    IEnumerator AsyncLoad()
    {
        Debug.Log(SceneId);
        PrevSceneId = SceneManager.GetActiveScene().name;
        //LoadBackImage.gameObject.SetActive(true);
        //LoadImage.gameObject.SetActive(true);
        //LoadText.gameObject.SetActive(true);
        yield return new WaitForEndOfFrame();
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneId);

        while (!operation.isDone)
        {
            LoadImage.fillAmount = operation.progress / 0.9f;
            LoadText.text = string.Format("{0:0}%", operation.progress / 0.9 * 100);
            yield return null;
        }

    }
}