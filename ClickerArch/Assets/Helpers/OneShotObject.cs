using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotObject : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void Hide()
    {
        var sr = gameObject.GetComponent<SpriteRenderer>();

        if(sr != null)
        {
            sr.color = new Color(1, 1, 1, 0);
        }

        gameObject.GetComponent<Animator>().Play("Stop");
    }

    public void Show()
    {
        var sr = gameObject.GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.color = new Color(1, 1, 1, 1);
        }
    }
}
