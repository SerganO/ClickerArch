using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    private bool move;

    private Vector2 randomVector;

    void Update()
    {
        if (!move) return;
        transform.Translate(randomVector * Time.deltaTime);
    }

    /*public void StartMotion(int value)
    {
        transform.localPosition = Vector3.zero;
        GetComponent<Text>().text = value.ToString();
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        move = true;
        GetComponent<Animation>().Play();
    }*/

    public void StartMotion(string value)
    {
        transform.localPosition = Vector3.zero;
        GetComponent<Text>().text = value;
        randomVector = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        move = true;
        GetComponent<Animation>().Play();
    }

    public void StopMove()
    {
        GetComponent<Text>().text = "";
        move = false;
        transform.localPosition = Vector3.zero;
        
    }
}
