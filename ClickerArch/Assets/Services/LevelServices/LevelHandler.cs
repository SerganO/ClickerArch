using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Transform SpawnPoint;
    public string StartLevelID;
    public Image BackgroundImage;


    string CurrentID;
    List<IEnemy> enemies = new List<IEnemy>();
    IEnemy CurrentEnemy;

    private void Start()
    {
        CurrentID = StartLevelID;
        NextLevel();
    }

    int currentIndex = -1;

    void SetupForId(string ID)
    {
        var instance = Services.GetInstance();
        BackgroundImage.sprite = instance.GetLevelService().GetLevelViewForId(ID).GetBackgroundImage();
        enemies = instance.GetLevelService().GetLevelModelForId(ID).GetEnemies();        
    }

    public void NextEnemy()
    {
        currentIndex++;
        if (currentIndex >= enemies.Count) {
            NextLevel();
            return;
        }

        CurrentEnemy = enemies[currentIndex];
        CurrentEnemy.onDie += NextEnemy;
        Instantiate(CurrentEnemy, SpawnPoint);

    }

    public void NextLevel()
    {
        currentIndex = -1;
        
        //Magic change CurrntID

        SetupForId(CurrentID);
        NextEnemy();
    }


    public void OnClick()
    {
        var damage = Services.GetInstance().GetHero().DamageByTap;

        CurrentEnemy.Hurt(damage);
    }





}
