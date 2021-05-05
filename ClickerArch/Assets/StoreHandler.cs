using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreHandler : MonoBehaviour
{
    public SceneLoader Loader;
    public MoneyPanel MoneyPanel;
    public Transform GoodsListTransform;
    public CraftItem Item;
    public RecipeDetail DetailElement;

    ItemCategory CurrentCategory = ItemCategory.Thing;

    private void Start()
    {
        MoneyPanel.UpdateUI();
        UpdateGoodsList();
        Bind();
    }

    public void LoadMain()
    {
        Loader.Load(SceneLoader.Scene.Main);
    }


    void Bind()
    {
        DetailElement.OnAccept += DetailElement_OnCraft;
    }

    private void DetailElement_OnCraft()
    {
        UpdateGoodsList();
    }

    void Unbind()
    {
        DetailElement.OnAccept -= DetailElement_OnCraft;
    }

    private void OnDestroy()
    {
        Unbind();
    }

    public void UpdateGoodsList()
    {
        Helper.ClearTransform(GoodsListTransform);

        Services.GetInstance().GetDataService().GetGoodsList(CurrentCategory, (list) =>
        {
            list.ForEach(recipe =>
            {
                var item = Instantiate(Item, GoodsListTransform);
                item.SetupForRecipe(recipe);
                item.InfoButton.onClick.AddListener(() => {
                    ShowCraftDetail(recipe);
                });

                item.ActionButton.onClick.AddListener(() => {
                    AcceptPurchase(recipe);
                });
                item.ActionButton.interactable = CraftMaster.CanCraft(recipe);

            });

        });
    }

    public void UpdateForThing()
    {
        if(CurrentCategory != ItemCategory.Thing)
        {
            CurrentCategory = ItemCategory.Thing;
            UpdateGoodsList();
        }
        
    }

    public void UpdateForClothes()
    {
        if (CurrentCategory != ItemCategory.Clothes)
        {
            CurrentCategory = ItemCategory.Clothes;
            UpdateGoodsList();
        }

    }

    public void UpdateForWeapon()
    {
        if (CurrentCategory != ItemCategory.Weapon)
        {
            CurrentCategory = ItemCategory.Weapon;
            UpdateGoodsList();
        }

    }

    public void UpdateForTransport()
    {
        if (CurrentCategory != ItemCategory.Transport)
        {
            CurrentCategory = ItemCategory.Transport;
            UpdateGoodsList();
        }

    }

    public void AcceptPurchase(Recipe recipe)
    {
        CraftMaster.Craft(recipe);
        DetailElement_OnCraft();
    }


    public void ShowCraftDetail(Recipe recipe)
    {
        DetailElement.ShowDetailForRecipe(recipe);
        DetailElement.gameObject.SetActive(true);
    }

    public void UpdateForSkills()
    {
        if (CurrentCategory != ItemCategory.Skill)
        {
            CurrentCategory = ItemCategory.Skill;

            Helper.ClearTransform(GoodsListTransform);

            List<HeroParameter> list = new List<HeroParameter>
            {

            };

            list.ForEach(parameter =>
            {
                var item = Instantiate(Item, GoodsListTransform);
                item.SetupForSkill(parameter);
                item.InfoButton.onClick.AddListener(() => {
                    //ShowCraftDetail(recipe);
                });

                item.ActionButton.onClick.AddListener(() => {
                    //AcceptPurchase(recipe);
                });
                //item.ActionButton.interactable = CraftMaster.CanCraft(recipe);

            });




        }
    }
}
