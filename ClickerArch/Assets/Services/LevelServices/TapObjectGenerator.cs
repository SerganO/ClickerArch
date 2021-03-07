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

    private GameObject[] objectPool = new GameObject[15];

    int currentIndex = 0;

    float rotationOffset = 0.1f;

    private void Start()
    {
        for (int i = 0; i < objectPool.Length; i++)
        {
            objectPool[i] = Instantiate(TapObject, TapParentObject.transform);
            objectPool[i].GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
        }
    }

    public void Generate(Vector3 position)
    {
        var currentObject = objectPool[currentIndex];
        currentObject.transform.position = position;
        currentObject.transform.rotation = RandomRotate ? RandomQuaternion() : Quaternion.identity;
        //objectPool[currentIndex].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        currentObject.GetComponent<Animator>().Play("shot");
        currentIndex = currentIndex + 1 < objectPool.Length ? currentIndex + 1 : 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = position.z / 2;
        Generate(position);  
    }

    Quaternion RandomQuaternion()
    {
        return new Quaternion(RandomRotationComponent(), RandomRotationComponent(), RandomRotationComponent(), RandomRotationComponent());
    }

    float RandomRotationComponent()
    {
        var r1 = Random.Range(-rotationOffset, 0f);
        var r2 = Random.Range(0, rotationOffset);

        return (int)Random.Range(0, 100) % 2 == 0 ? r1 : r2;
    }
}
