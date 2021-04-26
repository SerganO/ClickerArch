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

    ItemCategory CurrentCategory = ItemCategory.Thing;

    private void Start()
    {
        ResourcesPanel.UpdateUI();
        MoneyPanel.UpdateUI();
        UpdateRecipesList();
        Bind();
    }

    void Bind()
    {
        DetailElement.OnAccept += DetailElement_OnCraft;
    }

    private void DetailElement_OnCraft()
    {
        ResourcesPanel.UpdateUI();
        UpdateRecipesList();
    }

    void Unbind()
    {
        DetailElement.OnAccept -= DetailElement_OnCraft;
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

        Services.GetInstance().GetPlayer().Inventory.Recipes.FindAll(recipe=>recipe.Category == CurrentCategory).ForEach(recipe=>
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
    public void UpdateForThing()
    {
        if (CurrentCategory != ItemCategory.Thing)
        {
            CurrentCategory = ItemCategory.Thing;
            UpdateRecipesList();
        }

    }

    public void UpdateForClothes()
    {
        if (CurrentCategory != ItemCategory.Clothes)
        {
            CurrentCategory = ItemCategory.Clothes;
            UpdateRecipesList();
        }

    }

    public void UpdateForWeapon()
    {
        if (CurrentCategory != ItemCategory.Weapon)
        {
            CurrentCategory = ItemCategory.Weapon;
            UpdateRecipesList();
        }

    }

    public void UpdateForTransport()
    {
        if (CurrentCategory != ItemCategory.Transport)
        {
            CurrentCategory = ItemCategory.Transport;
            UpdateRecipesList();
        }

    }

    public void AcceptCraft(Recipe recipe)
    {
        CraftMaster.Craft(recipe);
        DetailElement_OnCraft();
    }


    public void ShowCraftDetail(Recipe recipe)
    {
        
        DetailElement.gameObject.SetActive(true);
        DetailElement.ShowDetailForRecipe(recipe);
        

    }



}
