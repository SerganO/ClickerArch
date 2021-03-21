using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : Button
{
    public Image BackImage;
    public Image FrontImage;
    public Text TimeLabel;

    float tick = 0.1f;

    protected override void Start()
    {
        TimeLabel.text = "";
    }

    public void ConfigureForID(string id)
    {
        var image = Services.GetInstance().GetDataService().GetSpriteForID("Skills/" + id);
        BackImage.sprite = image;
        FrontImage.sprite = image;

    }

    public void Countdown(double time)
    {
       

        StartCoroutine(Countdown((float)time));
    }



    IEnumerator Countdown(float time)
    {
        interactable = false;
        var n = (int)(time / tick);

        for (int i = 0; i < n; i++)
        {
            FrontImage.fillAmount = (float)i / n;
            TimeLabel.text = ((int)(time - tick * i)).ToString();
            yield return new WaitForSeconds(tick);
        }

        TimeLabel.text = "";
        FrontImage.fillAmount = 1;
        interactable = true;
    }

}
