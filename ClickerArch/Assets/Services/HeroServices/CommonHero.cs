using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHero : IHero
{
    double TICK_TIME = 1.0;
    double tick = 0;

    private int MockDPC = 9;
    private int MockDPS = 5;

    public event VoidFunc OnHurt;
    public event VoidFunc OnDie;
    public event AttackFunc AdditionalConstAttack;
    public event AttackFunc AdditionalCoefAttack;
    public event VoidFunc OnHeal;

    public double BaseDamagePerClick { get; set; }
    public double BaseDamagePerSecond { get; set; }
    public double BaseBlock { get; set; }
    public double Reflect { get; set; }
    public double MaximumHealthPoint { get; set; }
    public double CurrentHealthPoint { get; set; }
    public List<Modificator> Modificators { get; set; } = new List<Modificator>();
    public List<HeroSkill> Skills { get; set; } = new List<HeroSkill>();

    List<Modificator> AttackModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OnAttack); ;
        }
    }

    List<Modificator> HurtModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OnHurt); ;
        }
    }

    List<Modificator> StartModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OnStart); ;
        }
    }

    List<Modificator> TickModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.Tick); ;
        }
    }

    List<Modificator> OneShotModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OneShot); ;
        }
    }

    public double CurrentDamagePerClick
    {
        get
        {
            return GetDPCDamage(BaseDamagePerClick, AttackModificators);
        }
    }

    public double CurrentDamagePerSecond
    {
        get
        {
            return GetDPSDamage(BaseDamagePerSecond, AttackModificators);
        }
    }

    public CommonHero()
    {
        BaseDamagePerClick = MockDPC;
        BaseDamagePerSecond = MockDPS;
        CurrentHealthPoint = 20;
        MaximumHealthPoint = 20;

        //Mock
        AddModificators(new List<Modificator>
        {
            ModificatorFactory.ModificatorForString("Reflect=Current=OnHurt=Coef=2=1=1=1=Permanent")
        });

        new List<HeroSkill>
        {
            new HeroSkill
            {
                ID="heal",
                Countdown = 60,
                Modificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForString("HP=Current=OneShot=Const=10=1=1=1=OneShot|Reflect=Current=OnHurt=Coef=2=1=1=1=Permanent")
                }
            },
            new HeroSkill
            {
                ID="attack",
                Countdown = 60,
                Modificators = new List<Modificator>
                {
                     ModificatorFactory.ModificatorForString("DPC=Current=OnAttack=Const=0=1=10=1=Replacing|DPC=Current=OnAttack=AddConst=5=10=10=1=Replacing"),
                    //ModificatorFactory.ModificatorForString("DPC=Current=OnAttack=Const=100=1=1=1=OneShot")
                }
            }

        }.ForEach(skill =>
        {
            Skills.Add(skill);
        });
    }

    public void AddModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Add(mod));

    }

    public void Attack(IEnemy enemy)
    {
        var damage = GetDPCDamage(BaseDamagePerClick, AttackModificators);
        enemy.Hurt(damage);
        AttackModificators.FindAll(mod => mod.endType == ModificatorEndType.Replacing).ForEach(mod => mod.Replace());
    }

    public double GetDPCDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;
        var dpcMods = mods.FindAll(mod => mod.parameter== ModificatorParameter.DPC && mod.valueType == ModificatorValueType.Current);

        dpcMods.ForEach(mod =>
        {
            switch (mod.changeType)
            {
                case ModificatorValueChangeType.Const:
                    damage += mod.value;
                    break;
                case ModificatorValueChangeType.Coef:
                    damage += baseDamage * mod.value;
                    break;
            }
        });

        return damage;
    }

    public double GetDPSDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;

        var dpsMods = mods.FindAll(mod => mod.parameter == ModificatorParameter.DPS && mod.valueType == ModificatorValueType.Current);

        dpsMods.ForEach(mod =>
        {
            switch (mod.changeType)
            {
                case ModificatorValueChangeType.Const:
                    damage += mod.value;
                    break;
                case ModificatorValueChangeType.Coef:
                    damage += baseDamage * mod.value;
                    break;
            }
        });

        return damage;
    }

    public double GetAfterBlockDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;
        var block = BaseBlock;


        var blockMods = mods.FindAll(mod => mod.parameter == ModificatorParameter.Block && mod.valueType == ModificatorValueType.Current);

        blockMods.ForEach(mod =>
        {
            switch (mod.changeType)
            {
                case ModificatorValueChangeType.Const:
                    block += mod.value;
                    break;
                case ModificatorValueChangeType.Coef:
                    block += baseDamage * mod.value;
                    break;
            }
        });

        return damage;
    }

    public double GetReflectionDamage(double baseDamage, List<Modificator> mods)
    {
        
        var damage = baseDamage * Reflect;

        var reflectMods = mods.FindAll(mod => mod.parameter == ModificatorParameter.Reflect && mod.valueType == ModificatorValueType.Current);

        reflectMods.ForEach(mod =>
        {
            switch (mod.changeType)
            {
                case ModificatorValueChangeType.Const:
                    damage += mod.value;
                    break;
                case ModificatorValueChangeType.Coef:
                    damage += baseDamage * mod.value;
                    break;
            }
        });

        return damage;
    }



    public void Death()
    {
        OnDie?.Invoke();
    }

    public void Hurt(double damage)
    {
        var gettedDamage = GetAfterBlockDamage(damage, HurtModificators);
        CurrentHealthPoint -= gettedDamage;
        OnHurt?.Invoke();
        if(CurrentHealthPoint <= 0)
        {
            Death();
        }
        var reflection = GetReflectionDamage(gettedDamage, HurtModificators);
        if(reflection != 0) AdditionalConstAttack?.Invoke(reflection, true);
    }

    public void Heal(double value)
    {
        CurrentHealthPoint = Mathf.Min((float)MaximumHealthPoint, (float)(CurrentHealthPoint + value));
        OnHeal?.Invoke();
    }

    public void RemoveModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Remove(mod));
    }

    public void UpdateOnTick(double time)
    {
        var oneShotMods = Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OneShot);
        ReactOnModificators(oneShotMods);

        Debug.Log(Modificators.Count);
        Modificators.ForEach(mod=>Debug.Log(mod));
        tick += time;
        if(tick >= TICK_TIME)
        {
            tick -= TICK_TIME;
            Debug.Log(TickModificators.Count);
            ReactOnModificators(TickModificators);
        }

        UpdateModificators(time);
        Debug.Log(Modificators.Count);
    }

    public void UpdateModificators(double time)
    {
        
        var tempMods = Modificators.FindAll(mod => mod.endType != ModificatorEndType.Permanent);
        tempMods.ForEach(mod => mod.time -= time);


        var modsForRemove = Modificators.FindAll(mod => mod.Check());
        RemoveModificators(modsForRemove);
        
    }

    public void ReactOnModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Debug.Log(mod));
        modificators.ForEach(mod => ReactOnModificator(mod));
    }

    public void ReactOnModificator(Modificator modificator)
    {
        double constPart = 0;
        double coefPart = 0;

        switch (modificator.changeType)
        {
            case ModificatorValueChangeType.Const:
                constPart += modificator.value;
                break;
            case ModificatorValueChangeType.Coef:
                coefPart += modificator.value;
                break;
            case ModificatorValueChangeType.AddConst:
                break;
            case ModificatorValueChangeType.AddCoef:
                break;
        }

        switch (modificator.valueType)
        {
            case ModificatorValueType.Base:
                switch (modificator.parameter)
                {
                    case ModificatorParameter.HP:
                        MaximumHealthPoint += constPart + MaximumHealthPoint * coefPart;
                        break;
                    case ModificatorParameter.DPC:
                        BaseDamagePerClick += constPart + BaseDamagePerClick * coefPart;
                        break;
                    case ModificatorParameter.DPS:
                        BaseDamagePerSecond += constPart + BaseDamagePerSecond * coefPart;
                        break;
                    case ModificatorParameter.Reflect:
                        Reflect += constPart + Reflect * coefPart;
                        break;
                    case ModificatorParameter.Block:
                        BaseBlock += constPart + BaseBlock * coefPart;
                        break;
                }
                break;
            case ModificatorValueType.Current:
                switch (modificator.parameter)
                {
                    case ModificatorParameter.HP:
                        var change = constPart + CurrentHealthPoint * coefPart;
                        Debug.Log("HP: " + change);
                        if (change < 0)
                        {
                            Hurt(change);
                        }
                        else
                        {
                            Heal(change);
                        }
                        break;
                    case ModificatorParameter.DPC:
                        break;
                    case ModificatorParameter.DPS:
                        break;
                    case ModificatorParameter.Reflect:
                        break;
                    case ModificatorParameter.Block:
                        break;
                }
                break;
        }
    }

    public void PassiveAttack(IEnemy enemy)
    {
        enemy.Hurt(GetDPSDamage(BaseDamagePerSecond, AttackModificators), false);
    }
}
