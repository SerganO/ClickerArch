using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public ResourcesPanel ResourcesPanel;
    public MoneyPanel MoneyPanel;

    public Transform CraftListTransform;

    public CraftItem CraftItem;

    public RecipeDetail DetailElement;

    private void Start()
    {
        ResourcesPanel.UpdateUI();
        MoneyPanel.UpdateUI();
        UpdateRecipesList();
        Bind();
    }

    void Bind()
    {
        DetailElement.OnCraft += DetailElement_OnCraft;
    }

    private void DetailElement_OnCraft()
    {
        ResourcesPanel.UpdateUI();
        UpdateRecipesList();
    }

    void Unbind()
    {
        DetailElement.OnCraft -= DetailElement_OnCraft;
    }

    private void OnDestroy()
    {
        Unbind();
    }

    public void LoadMain()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }

    public void UpdateRecipesList()
    {
        Helper.ClearTransform(CraftListTransform);

        Services.GetInstance().GetPlayer().Inventory.Recipes.ForEach(recipe=>
        {
            var item = Instantiate(CraftItem, CraftListTransform);
            item.SetupForRecipe(recipe);
            item.InfoButton.onClick.AddListener(()=> {
                ShowCraftDetail(recipe);
            });

            item.ActionButton.onClick.AddListener(() => {
                AcceptCraft(recipe);
            });
            item.ActionButton.interactable = CraftMaster.CanCraft(recipe);

        });
    }
    public void AcceptCraft(Recipe recipe)
    {
        CraftMaster.Craft(recipe);
        DetailElement_OnCraft();
    }


    public void ShowCraftDetail(Recipe recipe)
    {
        DetailElement.ShowDetailForRecipe(recipe);
        DetailElement.gameObject.SetActive(true);
    }



}
