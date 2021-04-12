using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services
{
    static IHeroService HeroService = new CommonHeroService();
    static ILevelService LevelService = new CommonLevelService();
    static IEnemyService EnemyService = new CommonEnemyService();
    static IDataService DataService = new ResourcesDataService();

    static Player Player = new Player();

    private Services() { }
    private static Services instance;

    public static void SetPlayer(Player player)
    {
        Player = player;
    }
    public static void SetLevelService(IHeroService heroService)
    {
        HeroService = heroService;
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

    public Player GetPlayer()
    {
        return Player;
    }
    public IHeroService GetHeroService()
    {
        return HeroService;
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
