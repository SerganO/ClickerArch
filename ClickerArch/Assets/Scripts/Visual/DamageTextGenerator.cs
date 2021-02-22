using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextGenerator : MonoBehaviour
{
    public GameObject ClickParent, DamageText;

    private DamageText[] objectPool = new DamageText[15];

    int currentIndex = 0;

    private void Start()
    {
        for(int i=0;i< objectPool.Length;i++)
        {
            objectPool[i] = Instantiate(DamageText, ClickParent.transform).GetComponent<DamageText>();
        }
    }

    public void Generate(int value)
    {
        objectPool[currentIndex].StartMotion(value);
        currentIndex = currentIndex + 1 < objectPool.Length ? currentIndex + 1 : 0;
    }
}
