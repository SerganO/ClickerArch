using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageAnimator : MonoBehaviour
{
    public List<Sprite> sprites;

    public float delay;

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    int index = 0;
    float time = 0;


    // Update is called once per frame
    void Update()
    {
        if (sprites.Count <= 0) return;
        time += Time.deltaTime;

        if (time >= delay)
        {
            time -= delay;
            if (index + 1 >= sprites.Count)
            {
                index = 0;
            }
            else {
                index++;
            }

            image.sprite = sprites[index];


        }
    }
}
