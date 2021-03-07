using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapObjectGenerator : MonoBehaviour, IPointerDownHandler
{
    public GameObject TapParentObject;
    public GameObject TapObject;

    public bool RandomRotate = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        var position = Camera.main.ScreenToWorldPoint(eventData.position);

        position.z = position.z / 2; 



        Instantiate(TapObject, position, RandomRotate ? randomQuaternion(): Quaternion.identity, TapParentObject.transform);
    }

    Quaternion randomQuaternion()
    {
        return new Quaternion(rrc(), rrc(), rrc(), rrc());
    }

    float rrc()
    {
        var r1 = Random.Range(-0.1f, 0f);
        var r2 = Random.Range(0, 0.1f);

        return (int)Random.Range(0, 100) % 2 == 0 ? r1 : r2;
    }
}
