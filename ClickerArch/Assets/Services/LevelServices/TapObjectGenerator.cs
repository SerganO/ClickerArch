using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapObjectGenerator : MonoBehaviour, IPointerDownHandler
{
    public GameObject TapParentObject;
    public GameObject TapObject;


    public void OnPointerDown(PointerEventData eventData)
    {
        var position = Camera.main.ScreenToWorldPoint(eventData.position);

        position.z = -5;
        Debug.Log(position);  

        Instantiate(TapObject, position, Quaternion.identity, TapParentObject.transform);
    }
}
