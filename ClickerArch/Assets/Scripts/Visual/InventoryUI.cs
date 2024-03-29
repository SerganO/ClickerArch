﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform ListContent;
    public InventoryItemScript InventoryItem;
    public MoneyPanel MoneyPanel;

    public RecipeDetail DetailElement;

    ItemCategory CurrentCategory = ItemCategory.Thing;

    public void UpdateUI()
    {
        MoneyPanel.UpdateUI();
        UpdateList();
    }

    public void ClearItems()
    {
        foreach(Transform child in ListContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void SwitchToClothes()
    {
        ClearItems();

        InventoryItemScript ActiveItem = Instantiate(InventoryItem, ListContent);
        ActiveItem.SetupAsClothes(Services.GetInstance().GetPlayer().CurrentHeroId, ()=> { UpdateListWithoutMove(); });
        ActiveItem.InfoButton.onClick.AddListener(() => {
            DetailElement.ShowDetailForHero(Services.GetInstance().GetPlayer().CurrentHeroId, () => { UpdateListWithoutMove(); });
            DetailElement.gameObject.SetActive(true);
        });
        ActiveItem.GetComponent<Image>().color = Color.green;


        Services.GetInstance().GetPlayer().AvailableHeroes.ForEach((id) =>
        {

            InventoryItemScript item = Instantiate(InventoryItem, ListContent);
            item.GetComponent<Image>().color = Color.white;
            item.SetupAsClothes(id, () => { UpdateListWithoutMove(); });
            item.InfoButton.onClick.AddListener(()=> {
                DetailElement.ShowDetailForHero(id, () => { UpdateListWithoutMove(); });
                DetailElement.gameObject.SetActive(true);
            });

        });

    }

    public void UpdateList()
    {
        var player = Services.GetInstance().GetPlayer();
        var inventory = player.Inventory;

        ClearItems();

        switch (CurrentCategory)
        {
            case ItemCategory.Thing:
                player.ActiveArtifacts.ForEach(item =>
                {
                    if (item != null && !item.IsEmpty())
                    {
                        InventoryItemScript activeArtifactsItem = Instantiate(InventoryItem, ListContent);
                        activeArtifactsItem.GetComponent<Image>().color = Color.green;
                        var arcSprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + item.id);
                        activeArtifactsItem.ActionButton.onClick.RemoveAllListeners();
                        activeArtifactsItem.ActionButton.onClick.AddListener(() =>
                        {
                            player.UnsetArtifacts(item);
                            UpdateListWithoutMove();
                        });
                        var data = LocalizationManager.GetDataForItemId(item.id);
                        var countText = "";
                        if (item.count > 1) countText = " x" + item.count;
                        activeArtifactsItem.Setup(arcSprite, data.name + countText);
                        activeArtifactsItem.InfoButton.onClick.AddListener(() =>
                        {
                            DetailElement.ShowDetailForItem(item, () =>
                            {
                                player.UnsetArtifacts(item);
                                UpdateListWithoutMove();
                            });
                            DetailElement.gameObject.SetActive(true);
                        });
                    }
                });

                inventory.Items.FindAll(item => item.Category == CurrentCategory).ForEach(item => {
                    InventoryItemScript uiItem = Instantiate(InventoryItem, ListContent);
                    uiItem.GetComponent<Image>().color = Color.white;
                    uiItem.ActionButton.onClick.RemoveAllListeners();
                    uiItem.ActionButton.onClick.AddListener(() =>
                    {
                        player.AddArtifacts(item);
                        UpdateListWithoutMove();
                    });
                    var _arcSprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + item.id);
                    var data = LocalizationManager.GetDataForItemId(item.id);
                    var countText = "";
                    if (item.count > 1) countText = " x" + item.count;
                    uiItem.Setup(_arcSprite, data.name + countText);
                    uiItem.InfoButton.onClick.AddListener(() => {
                        DetailElement.ShowDetailForItem(item, () => {
                            player.AddArtifacts(item);
                            UpdateListWithoutMove();
                        });
                        DetailElement.gameObject.SetActive(true);
                    });

                });

                break;
            case ItemCategory.Clothes:
                SwitchToClothes();
                return;
            case ItemCategory.Weapon:
                if (player.ActiveWeapon != null)
                {
                    InventoryItemScript activeWeapon = Instantiate(InventoryItem, ListContent);
                    activeWeapon.GetComponent<Image>().color = Color.green;
                    var weaponSprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + player.activeWeapon.id);
                    activeWeapon.ActionButton.onClick.RemoveAllListeners();
                    activeWeapon.ActionButton.onClick.AddListener(() =>
                    {
                        player.UnsetWeapon();
                        UpdateListWithoutMove();
                    });
                    var data = LocalizationManager.GetDataForItemId(player.activeWeapon.id);
                    activeWeapon.Setup(weaponSprite, data.name);
                    activeWeapon.InfoButton.onClick.AddListener(() =>
                    {
                        DetailElement.ShowDetailForItem(player.activeWeapon, () =>
                        {
                            player.UnsetWeapon();
                            UpdateListWithoutMove();
                        });
                        DetailElement.gameObject.SetActive(true);
                    });
                }
                inventory.Items.FindAll(item => item.Category == CurrentCategory).ForEach(item => {
                    InventoryItemScript uiItem = Instantiate(InventoryItem, ListContent);
                    uiItem.GetComponent<Image>().color = Color.white;
                    uiItem.ActionButton.onClick.RemoveAllListeners();
                    uiItem.ActionButton.onClick.AddListener(() =>
                    {
                        player.SetWeapon(item);
                        UpdateListWithoutMove();
                    });
                    var _weaponSprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + item.id);
                    var data = LocalizationManager.GetDataForItemId(item.id);
                    var countText = "";
                    if (item.count > 1) countText = " x" + item.count;
                    uiItem.Setup(_weaponSprite, data.name + countText);
                    uiItem.InfoButton.onClick.AddListener(() => {
                        DetailElement.ShowDetailForItem(item, () => {
                            player.SetWeapon(item);
                            UpdateListWithoutMove();
                        });
                        DetailElement.gameObject.SetActive(true);
                    });

                });


                break;
            case ItemCategory.Transport:

                if (player.ActiveTransport != null)
                {
                    InventoryItemScript activeTransport = Instantiate(InventoryItem, ListContent);
                    activeTransport.GetComponent<Image>().color = Color.green;
                    var transportSprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + player.activeTransport.id);
                    activeTransport.ActionButton.onClick.RemoveAllListeners();
                    activeTransport.ActionButton.onClick.AddListener(() =>
                    {
                        player.UnsetTransport();
                        UpdateListWithoutMove();
                    });
                    var data = LocalizationManager.GetDataForItemId(player.activeTransport.id);
                    activeTransport.Setup(transportSprite, data.name);
                    activeTransport.InfoButton.onClick.AddListener(() =>
                    {
                        DetailElement.ShowDetailForItem(player.activeTransport, () =>
                        {
                            player.UnsetTransport();
                            UpdateListWithoutMove();
                        });
                        DetailElement.gameObject.SetActive(true);
                    });
                }
                inventory.Items.FindAll(item => item.Category == CurrentCategory).ForEach(item => {
                    InventoryItemScript uiItem = Instantiate(InventoryItem, ListContent);
                    uiItem.GetComponent<Image>().color = Color.white;
                    uiItem.ActionButton.onClick.RemoveAllListeners();
                    uiItem.ActionButton.onClick.AddListener(() =>
                    {
                        player.SetTransport(item);
                        UpdateListWithoutMove();
                    });
                    var _transportSprite = Services.GetInstance().GetDataService().GetSpriteForID("Items/" + item.id);
                    var data = LocalizationManager.GetDataForItemId(item.id);
                    var countText = "";
                    if (item.count > 1) countText = " x" + item.count;
                    uiItem.Setup(_transportSprite, data.name + countText);
                    uiItem.InfoButton.onClick.AddListener(() => {
                        DetailElement.ShowDetailForItem(item, () => {
                            player.SetTransport(item);
                            UpdateListWithoutMove();
                        });
                        DetailElement.gameObject.SetActive(true);
                    });

                });


                break;
            case ItemCategory.Skill:
                SwitchToParameters();
                return;
        }
    }



    public void UpdateForThing()
    {
        if (CurrentCategory != ItemCategory.Thing)
        {
            CurrentCategory = ItemCategory.Thing;
            UpdateList();
        }

    }

    public void UpdateForClothes()
    {
        if (CurrentCategory != ItemCategory.Clothes)
        {
            CurrentCategory = ItemCategory.Clothes;
            SwitchToClothes();
        }

    }

    public void UpdateForWeapon()
    {
        if (CurrentCategory != ItemCategory.Weapon)
        {
            CurrentCategory = ItemCategory.Weapon;
            UpdateList();
        }

    }

    public void UpdateForTransport()
    {
        if (CurrentCategory != ItemCategory.Transport)
        {
            CurrentCategory = ItemCategory.Transport;
            UpdateList();
        }

    }

    public void UpdateForParameters()
    {
        if (CurrentCategory != ItemCategory.Skill)
        {
            CurrentCategory = ItemCategory.Skill;
        }
            SwitchToParameters();
        

    }

    void SwitchToParameters()
    {
        var dataServices = Services.GetInstance().GetDataService();

        Helper.ClearTransform(ListContent); 

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
            var item = Instantiate(InventoryItem, ListContent);
            item.SetupForSkill(parameter);
            item.InfoButton.onClick.AddListener(() => {
                ShowCraftDetail(parameter);
            });

            item.ActionButton.gameObject.SetActive(false);
            //item.ActionButton.onClick.AddListener(() => {
            //    AcceptPurchase(parameter);
            //});

        });



    }

    public void ShowCraftDetail(HeroParameter parameter)
    {
        DetailElement.ShowDetailForParameter(parameter, false);
        DetailElement.gameObject.SetActive(true);
    }

    void UpdateListWithoutMove()
    {
        var y = ListContent.localPosition.y;
        UpdateList();
        ListContent.localPosition = new Vector3(ListContent.localPosition.x, y, ListContent.localPosition.z);
    }

}
