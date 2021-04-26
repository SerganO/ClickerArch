using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string PlayerId = "";
    public string Username = "";


    public Player(string username)
    {
        PlayerId = System.Guid.NewGuid().ToString();
        Username = username;
    }



    string currentHeroID = "";

    public string CurrentHeroId {
        get
        {
            if(currentHeroID == "")
            {
                if(availableHeroes.Count > 0)
                {
                    currentHeroID = availableHeroes[0];
                }
            }

            return currentHeroID;
        }

        set
        {
            currentHeroID = value;
        }

    }

    public event VoidFunc OnXPRaise;
    public event VoidFunc OnGoldChange;

    double gold = 0;

    public double Gold
    {
        get
        {
            return gold;
        }
    }

    public double XP { get; set; }
    public int CoolLevel { get; set; }


    double MaximumHealthPoint { get; set; }
    double BaseDamagePerClick { get; set; }
    double BaseDamagePerSecond { get; set; }
    double BaseBlock { get; set; }
    double BaseReflect { get; set; }

    public Inventory Inventory { get; set; } = new Inventory() {
       

        Recipes = new List<Recipe> {
            Services.GetInstance().GetDataService().GetRecipeForId("rare_resource"),
            Services.GetInstance().GetDataService().GetRecipeForId("epic_resource"),
            Services.GetInstance().GetDataService().GetRecipeForId("legendary_resource"),
            Services.GetInstance().GetDataService().GetRecipeForId("hero_sword"),
    } };

    public List<string> availableHeroes = new List<string>() {
        //COMMON
        "Adventurer",
        "ArenaWarrior",
        "ArmorWarrior",
        "Assassin",
        "CityBouncer",
        "Cyberclockwerk",
        "Gunslinger",
        "Hastat",
        "LightBandit",
        "MedievalKing",
        "Ninja",
        "Squire",

        //RARE

        //"Archer",
        //"HeroKnight",
        //"Janissary",
        //"GothicHero",
        //"Blacksmith",
        //"BlueKing",
        //"Monk",
        //"Ranger",
        //"Robot",
        //"RoyalKnight",
        //"Samurai",
        //"Striker",
        //"Wizard",


    };

    public void AddXP(double count)
    {
        XP += count;
        CheckLevelUp();
        OnXPRaise?.Invoke();
    }

    public void CheckLevelUp()
    {
        var neededXp = Services.GetInstance().GetDataService().GetXpForNextLevel(CoolLevel);
        while (XP >= neededXp)
        {
            XP -= neededXp;
            CoolLevel++;
            neededXp = Services.GetInstance().GetDataService().GetXpForNextLevel(CoolLevel);
        }
    }

    public void ZeroGold()
    {
        gold = 0;
        OnGoldChange?.Invoke();
    }

    public void AddGold(double count)
    {
        gold += count;
        OnGoldChange?.Invoke();
    }

    public bool Purchase(double count)
    {
        if (gold >= count)
        {
            gold -= count;
            OnGoldChange?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveGold(double count)
    {
        gold -= count;
        OnGoldChange?.Invoke();
    }
}
