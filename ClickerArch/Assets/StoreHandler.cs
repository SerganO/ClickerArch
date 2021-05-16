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

    private void DetailElement_OnUpgrade()
    {
        var y = GoodsListTransform.localPosition.y;
        UpdateForSkills();
        GoodsListTransform.localPosition = new Vector3(GoodsListTransform.localPosition.x, y, GoodsListTransform.localPosition.z);
    }

    void Unbind()
    {
        DetailElement.OnAccept -= DetailElement_OnCraft;
    }

    private void OnDestroy()
    {
        Unbind();
    }


    void SetupForClothes()
    {
        if (CurrentCategory != ItemCategory.Clothes)
        {
            CurrentCategory = ItemCategory.Clothes;

        }
        Helper.ClearTransform(GoodsListTransform);

        Services.GetInstance().GetDataService().GetHeroList((list) =>
        {
            list.ForEach(cloth =>
            {

                var item = Instantiate(Item, GoodsListTransform);
                item.SetupAsClothes(cloth, () => { DetailElement_OnCraft(); });
                item.InfoButton.onClick.AddListener(() => {
                    DetailElement.ShowStoreDetailForHero(cloth, ()=> { DetailElement_OnCraft(); });
                    DetailElement.gameObject.SetActive(true);
                });
                item.ActionButton.interactable = Services.GetInstance().GetPlayer().Gold >= Services.GetInstance().GetDataService().CostForClothes(cloth);
            });

       });
   }


    public void UpdateGoodsList()
    {
        if(CurrentCategory == ItemCategory.Skill)
        {
            UpdateForSkills();
            return;
        }

        if (CurrentCategory == ItemCategory.Clothes)
        {
            SetupForClothes();
            return;
        }


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

    public void AcceptPurchase(string heroId)
    {
        var player = Services.GetInstance().GetPlayer();
        var cost = Services.GetInstance().GetDataService().CostForClothes(heroId);
        player.Purchase(cost);
        player.availableHeroes.Add(heroId);
        DetailElement_OnCraft();
    }

    public void AcceptPurchase(HeroParameter parameter)
    {
        var newLevel = Services.GetInstance().GetPlayer().LevelForParameter(parameter) + 1;
        Services.GetInstance().GetPlayer().Purchase(Services.GetInstance().GetDataService().CostForParameterForLevel(parameter, newLevel));
        Services.GetInstance().GetPlayer().UpgradeParameter(parameter);
        DetailElement_OnUpgrade();
    }


    public void ShowCraftDetail(Recipe recipe)
    {
        DetailElement.ShowDetailForRecipe(recipe);
        DetailElement.gameObject.SetActive(true);
    }

    public void ShowCraftDetail(HeroParameter parameter)
    {
        DetailElement.ShowDetailForParameter(parameter);
        DetailElement.gameObject.SetActive(true);
    }

    public void UpdateForSkills()
    {
        if (CurrentCategory != ItemCategory.Skill)
        {
            CurrentCategory = ItemCategory.Skill;

        }
            Helper.ClearTransform(GoodsListTransform);

            List<HeroParameter> list = new List<HeroParameter>
            {
                HeroParameter.HP,
                HeroParameter.DPC,
                HeroParameter.DPS,
                HeroParameter.Block,
                HeroParameter.Reflect,
                HeroParameter.AdditionalGold,
                HeroParameter.AdditionalXP,
            };

            list.ForEach(parameter =>
            {
                var item = Instantiate(Item, GoodsListTransform);
                item.SetupForSkill(parameter);
                item.InfoButton.onClick.AddListener(() => {
                    ShowCraftDetail(parameter);
                });

                item.ActionButton.onClick.AddListener(() => {
                    AcceptPurchase(parameter);
                });

                var dataService = Services.GetInstance().GetDataService();
                item.ActionButton.interactable = dataService.CanUpgradeParameter(parameter);

            });




        
    }
}
