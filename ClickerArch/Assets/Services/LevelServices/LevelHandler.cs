using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Transform SpawnPoint;
    public string StartLevelID;
    public int StartLevel;
    public Image BackgroundImage;
    public Text Level;

    string CurrentID;
    int CurrentLevel;
    List<IEnemy> enemies = new List<IEnemy>();
    IEnemy CurrentEnemy;

    private void Start()
    {
        CurrentID = StartLevelID;
        CurrentLevel = StartLevel;
        NextLevel();
    }

    int currentIndex = -1;

    void SetupForIdAndLevel(string ID, int level)
    {
        var instance = Services.GetInstance();
        BackgroundImage.sprite = instance.GetLevelService().GetLevelViewForId(ID).GetBackgroundImage();
        var model = instance.GetLevelService().GetLevelModelForId(ID);
        model.ConfigureForLevel(level);
        enemies = model.GetEnemies();
    }

    public void NextEnemy()
    {
        currentIndex++;
        if (currentIndex >= enemies.Count)
        {
            NextLevel();
            return;
        }
        CurrentEnemy = Instantiate(enemies[currentIndex], SpawnPoint);
        CurrentEnemy.onDie += NextEnemy;

    }

    public void NextLevel()
    {
        currentIndex = -1;
        //Magic change CurrentID

        CurrentLevel++;
        Level.text = CurrentLevel.ToString();
        SetupForIdAndLevel(CurrentID, CurrentLevel);
        NextEnemy();
    }


    public void OnClick()
    {
        var damage = Services.GetInstance().GetHero().DamageByTap;

        CurrentEnemy.Hurt(damage);
    }





}
