using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform ListContent;
    public InventoryItemScript InventoryItem;
    public MoneyPanel MoneyPanel;

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

        Services.GetInstance().GetPlayer().availableHeroes.ForEach((id) =>
        {
            InventoryItemScript item = Instantiate(InventoryItem, ListContent);
            item.SetupAsClothes(id);

        });

    }

    public void UpdateList()
    {
        ClearItems();

        Services.GetInstance().GetPlayer().Inventory.Items.FindAll(item => item.Category == CurrentCategory).ForEach(item => {
            InventoryItemScript uiItem = Instantiate(InventoryItem, ListContent);
            uiItem.Setup(null, item.name);
        });

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

}
