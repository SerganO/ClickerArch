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
    List<string> enemiesIDs = new List<string>();
    IEnemy CurrentEnemy;

    IEnemy enemy;

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
        enemiesIDs = model.GetEnemiesIDs();

        enemy = Services.GetInstance().GetEnemyService().GetEnemyPreset();
        
    }

    public void NextEnemy()
    {
        currentIndex++;
        if (currentIndex >= enemiesIDs.Count)
        {
            NextLevel();
            return;
        }

        CurrentEnemy = Instantiate(enemy, SpawnPoint);

        var id = enemiesIDs[currentIndex];
        Services.GetInstance().GetEnemyService().ConfigureEnemyForId(CurrentEnemy, id);

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
