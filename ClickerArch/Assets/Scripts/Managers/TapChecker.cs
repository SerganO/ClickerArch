using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapChecker : MonoBehaviour, IPointerDownHandler
{
    public LevelHandler handler;
    public void OnPointerDown(PointerEventData eventData)
    {
        handler.OnClick();
    }

}
