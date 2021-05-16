using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string PlayerId = "";
    public string Username = "";

    public Player()
    {
        Inventory.Recipes.AddRange(ResourcesDataService.ResourceRecipes);
    }

    public Player(string username)
    {
        PlayerId = System.Guid.NewGuid().ToString();
        Username = username;
        Inventory.Recipes.AddRange(ResourcesDataService.ResourceRecipes);
    }

    public int MaxArtifactsCount = 3;

    public Item activeTransport = null;
    public Item activeWeapon = null;
    /* new Item("hero_sword", "HERO SWORD", 1, new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|DPS+Coef+2+1|Permanent|Remove"),
                }, ItemCategory.Weapon);*/
    public List<Item> activeArtifacts = new List<Item>()
    {


    };

    public Item ActiveTransport
    {
        get
        {
            if (activeTransport != null && activeTransport.IsEmpty())
            {
                activeTransport = null;


            }
            return activeTransport;
        }
    }
    public Item ActiveWeapon {
        get
        {
            if (activeWeapon != null && activeWeapon.IsEmpty())
            {
                activeWeapon = null;
            }
            return activeWeapon;
        }
    }
    public List<Item> ActiveArtifacts { get { return activeArtifacts; } }


    public void UnsetWeapon()
    {
        if (activeWeapon != null)
        {
            Inventory.AddItem(activeWeapon);

        }
        activeWeapon = null;
    }

    public void UnsetTransport()
    {
        if (activeTransport != null)
        {
            Inventory.AddItem(activeTransport);

        }
        activeTransport = null;
    }

    public void UnsetArtifacts(Item item)
    {
        Inventory.AddItem(item);
        activeArtifacts.Remove(item);

    }

    public void SetWeapon(Item item)
    {
        var clone = (Item)item.Clone();
        clone.count = 1;
        Inventory.RemoveItem(clone);
        UnsetWeapon();
        activeWeapon = clone;
        
    }

    public void SetTransport(Item item)
    {
        Inventory.RemoveItem(item);
        if (activeTransport != null)
        {
            Inventory.AddItem(activeTransport);
        }
        activeTransport = item;

    }

    public void AddArtifacts(Item item)
    {
        if (activeArtifacts.Count >= MaxArtifactsCount)
        {
            UnsetArtifacts(activeArtifacts[0]);
        }
        var clone = (Item)item.Clone();
        clone.count = 1;
        activeArtifacts.Add(clone);
        Inventory.RemoveItem(clone);
    }


    List<Item> AllActiveItems
    {
        get
        {
            var result = new List<Item>();
            if (ActiveWeapon != null)
            {
                result.Add(ActiveWeapon);
            }

            if (ActiveTransport != null)
            {
                result.Add(ActiveTransport);
            }

            result.AddRange(ActiveArtifacts);


            return result;
        }
    }


    public event VoidFunc OnXPRaise;
    public event DoubleFunc OnXPDoubleRaise;
    public event VoidFunc OnGoldChange;
    public event DoubleFunc OnGoldDoubleChange;

    [SerializeField]
    double gold = 0;

    public double Gold
    {
        get
        {
            return gold;
        }
    }

    public double XP;
    public int CoolLevel;

    public int MaximumHealthPointLevel = 0;
    public int BaseDamagePerClickLevel = 0;
    public int BaseDamagePerSecondLevel = 0;
    public int BaseBlockLevel = 0;
    public int BaseReflectLevel = 0;
    public int AdditionalGoldLevel = 0;
    public int AdditionalXPLevel = 0;

    public int LevelForParameter(HeroParameter parameter)
    {
        switch (parameter)
        {
            case HeroParameter.HP:
                return MaximumHealthPointLevel;
            case HeroParameter.DPC:
                return BaseDamagePerClickLevel;
            case HeroParameter.DPS:
                return BaseDamagePerSecondLevel;
            case HeroParameter.Block:
                return BaseBlockLevel;
            case HeroParameter.Reflect:
                return BaseReflectLevel;
            case HeroParameter.AdditionalGold:
                return AdditionalGoldLevel;
            case HeroParameter.AdditionalXP:
                return AdditionalXPLevel;
        }

        return 0;
    }

    public void UpgradeParameter(HeroParameter parameter)
    {
        switch (parameter)
        {
            case HeroParameter.HP:
                MaximumHealthPointLevel++;
                break;
            case HeroParameter.DPC:
                BaseDamagePerClickLevel++;
                break;
            case HeroParameter.DPS:
                BaseDamagePerSecondLevel++;
                break;
            case HeroParameter.Block:
                BaseBlockLevel++;
                break;
            case HeroParameter.Reflect:
                BaseReflectLevel++;
                break;
            case HeroParameter.AdditionalGold:
                AdditionalGoldLevel++;
                break;
            case HeroParameter.AdditionalXP:
                AdditionalXPLevel++;
                break;
        }
    }

    IDataService dataService
    {
        get
        {
            return Services.GetInstance().GetDataService();
        }
    }

    double maximumHealthPoint { get { return dataService.MaximumHealthPointForLevel(MaximumHealthPointLevel); } }
    double baseDamagePerClick { get { return dataService.BaseDamagePerClickForLevel(BaseDamagePerClickLevel); } }
    double baseDamagePerSecond { get { return dataService.BaseDamagePerSecondForLevel(BaseDamagePerSecondLevel); } }
    double baseBlock { get { return dataService.BaseBlockForLevel(BaseBlockLevel); } }
    double baseReflect { get { return dataService.BaseReflectForLevel(BaseReflectLevel); } }
    double additionalGold { get { return dataService.AdditionalGoldForLevel(AdditionalGoldLevel); } }
    double additionalXP { get { return dataService.AdditionalXPForLevel(AdditionalXPLevel); } }


    public double MaximumHealthPoint { get { return maximumHealthPoint + AdditionalMaximumHealthPoint(); } }
    public double BaseDamagePerClick { get { return baseDamagePerClick + AdditionalBaseDamagePerClick(); } }
    public double BaseDamagePerSecond { get { return baseDamagePerSecond + AdditionalBaseDamagePerSecond(); } }
    public double BaseBlock { get { return baseBlock + AdditionalBaseBlock(); } }
    public double BaseReflect { get { return baseReflect + AdditionalBaseReflect(); } }
    public double AdditionalGold { get { return additionalGold + AdditionalAdditionalGold(); } }
    public double AdditionalXP { get { return additionalXP + AdditionalAdditionalXP(); } }

    public Inventory Inventory = new Inventory();/* {
        Items = new List<Item>
        {
            new Item("item_id_3", "DAMAGE RING", 1, new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPC|OnAttack|NONE+Const+5+1|Permanent|Remove"),
                }, ItemCategory.Thing),
            new Item("item_id_4", "HP RING", 1, new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP|OnStart|NONE+Const+100+1|Permanent|Remove"),
                }, ItemCategory.Thing),
            new Item("item_id_5", "PASSIVE DAMAGE RING", 1, new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("DPS|OnAttack|NONE+Const+5+1|Permanent|Remove"),
                }, ItemCategory.Thing),
            new Item("item_id_6", "XP RING", 1, new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("AdditionalXP|OnStart|NONE+Const+1+10|Permanent|Remove"),
                }, ItemCategory.Thing),

            new Item("horse", "horse", 1, new List<Modificator>(), ItemCategory.Transport),
            new Item("Car1", "Car1", 1, new List<Modificator>(), ItemCategory.Transport),
            new Item("Car2", "Car2", 1, new List<Modificator>(), ItemCategory.Transport),
            new Item("Car3", "Car3", 1, new List<Modificator>(), ItemCategory.Transport),
            new Item("Car4", "Car4", 1, new List<Modificator>(), ItemCategory.Transport),
            new Item("Car5", "Car5", 1, new List<Modificator>(), ItemCategory.Transport),



        },

        };*/




    double ValuesFromItemsForParameter(Modificator.Parameter parameter)
    {
        double result = 0;
        AllActiveItems.ForEach(item =>
        {
            item.modificators.FindAll(mod => mod.parameter == parameter).ForEach(modificator =>
            {

                modificator.values.ForEach(value =>
                {
                    switch (value.changeType)
                    {
                        case Modificator.ChangeValue.ValueChangeType.Const:
                            result += value.value;
                            break;
                        case Modificator.ChangeValue.ValueChangeType.Coef:
                            result += GetValue(value.baseParameter) * value.value;
                            break;
                    }
                });

            });
        });
        return result;
    }

    public double AdditionalMaximumHealthPoint() {
        return ValuesFromItemsForParameter(Modificator.Parameter.HP);
    }
    public double AdditionalBaseDamagePerClick() {
        return ValuesFromItemsForParameter(Modificator.Parameter.DPC);
    }
    public double AdditionalBaseDamagePerSecond() {
        return ValuesFromItemsForParameter(Modificator.Parameter.DPS);
    }
    public double AdditionalBaseBlock() {
        return ValuesFromItemsForParameter(Modificator.Parameter.Block);
    }
    public double AdditionalBaseReflect() {
        return ValuesFromItemsForParameter(Modificator.Parameter.Reflect);
    }
    public double AdditionalAdditionalGold() {
        return ValuesFromItemsForParameter(Modificator.Parameter.AdditionalGold);
    }
    public double AdditionalAdditionalXP() {
        return ValuesFromItemsForParameter(Modificator.Parameter.AdditionalXP);
    }

    double GetValue(Modificator.Parameter parameter)
    {
        switch (parameter)
        {
            case Modificator.Parameter.NONE:
                break;
            case Modificator.Parameter.HP:
                return maximumHealthPoint;
            case Modificator.Parameter.DPC:
                return baseDamagePerClick;
            case Modificator.Parameter.DPS:
                return baseDamagePerSecond;
            case Modificator.Parameter.Reflect:
                return baseReflect;
            case Modificator.Parameter.Block:
                return baseBlock;
            case Modificator.Parameter.AdditionalXP:
                return additionalXP;
            case Modificator.Parameter.AdditionalGold:
                return additionalGold;
            default:
                break;
        }

        return 0;
    }


    public void SetHeroId(string heroId)
    {
        if (currentHeroID != "") AvailableHeroes.Add(currentHeroID);
        currentHeroID = heroId;
        AvailableHeroes.Remove(currentHeroID);
    }

    [SerializeField]
    string currentHeroID = "Squire";

    public string CurrentHeroId
    {
        get
        {
            if (currentHeroID == "")
            {
                if (AvailableHeroes.Count > 0)
                {
                    SetHeroId(availableHeroes[0]);
                }
            }

            return currentHeroID;
        }

        set
        {
            currentHeroID = value;
        }

    }


    public List<string> availableHeroes = new List<string>() {
        
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

    public List<string> AvailableHeroes
    {
        get
        {
            availableHeroes.Sort();
            return availableHeroes;
        }
    }

    public void AddXP(double count)
    {
        XP += count;
        CheckLevelUp();
        OnXPRaise?.Invoke();
        OnXPDoubleRaise?.Invoke(count);
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
        OnGoldDoubleChange?.Invoke(count);
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
