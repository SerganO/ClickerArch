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
        new Recipe {

            Category = ItemCategory.Weapon,
            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Common, count = 4 },
                new Resource { rarity = Resource.Rarity.Rare, count = 1 },
            },

            RequiredGold = 678,

            ResultItem = new Item
            {
                Category = ItemCategory.Weapon,
                name = "Sword",
                modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Permanent|Remove"),
                    ModificatorFactory.ModificatorForString("CurrentDPS|OnAttack|DPC+Const+-2+1|Permanent|Remove"),
                }
            }
        },

        new Recipe {
            Category = ItemCategory.Thing,

            RequiredResources = new List<Resource>
            {
                new Resource { rarity = Resource.Rarity.Common, count = 5 },
            },

            RequiredGold = 10,

            ResultResource = new Resource { count = 1, rarity = Resource.Rarity.Rare },
            IsPermanent = true

        }


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
