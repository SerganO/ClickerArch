using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform ListContent;
    public InventoryItemScript InventoryItem;
    public MoneyPanel MoneyPanel;

    public void UpdateUI()
    {
        MoneyPanel.UpdateUI();
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


}
