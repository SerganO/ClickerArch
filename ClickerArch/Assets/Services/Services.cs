using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services
{
    static IHero Hero;
    static ILevelService LevelService;
    static IEnemyService EnemyService = new CommonEnemyService();
    static IDataService DataService = new ResourcesDataService();

    private Services() { }
    private static Services instance;

    public static void SetHero(IHero hero) {
        Hero = hero;
    }
    public static void SetLevelService(ILevelService levelService) {
        LevelService = levelService;
    }
    public static void SetEnemyService(IEnemyService enemyService) {
        EnemyService = enemyService;
    }
    public static void SetDataService(IDataService dataService) {
        DataService = dataService;
    }


    public static Services GetInstance()
    {
        if(instance == null)
        {
            instance = new Services();
        }
        return instance;
    }


    public IHero GetHero()
    {
        return Hero;
    }
    public ILevelService GetLevelService()
    {
        return LevelService;
    }
    public IEnemyService GetEnemyService()
    {
        return EnemyService;
    }
    public IDataService GetDataService()
    {
        return DataService;
    }
}
