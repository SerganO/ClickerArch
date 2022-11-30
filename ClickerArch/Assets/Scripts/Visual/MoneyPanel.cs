using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : MonoBehaviour
{
    public Text GoldLabel;
    public Image GoldIcon;

    private void Start()
    {
        Bind();
        UpdateUI();
    }

    public void UpdateUI()
    {
        GoldLabel.text = ((int)Services.GetInstance().GetPlayer().Gold).ToString();
    }

    public void Bind()
    {
        Services.GetInstance().GetPlayer().OnGoldChange += UpdateUI;
    }

    public void Unbind()
    {
        Services.GetInstance().GetPlayer().OnGoldChange -= UpdateUI;
    }

    private void OnDestroy()
    {
        Unbind();
    }
}
