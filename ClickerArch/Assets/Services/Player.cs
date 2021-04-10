using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
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

    double gold;

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

    public Inventory Inventory { get; set; } = new Inventory();

    public List<string> availableHeroes = new List<string>() {
        "Adventurer",
        "Archer",
        "ArenaWarrior",
        "ArmorWarrior",
        "Assassin",
        "Blacksmith",
        "BlueKing",
        "Cyberclockwerk",
        "GothicHero",
        "Gunslinger",
        "Hastat",
        "HeroKnight",
        "Janissary",
        "LightBandit",
        "MedievalKing",
        "MedievalWarrior",
        "Monk",
        "Ninja",
        "Ranger",
        "Robot",
        "RoyalKnight",
        "Samurai",
        "Squire",
        "Striker",
        "Wizard",


    };

    public void AddXP(double count)
    {
        XP += count;
        CheckLevelUp();
        OnXPRaise();
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
