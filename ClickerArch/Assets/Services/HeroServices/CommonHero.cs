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
    public double MaximumHealthPoint { get; set; }
    public double CurrentHealthPoint { get; set; }
    public List<Modificator> Modificators { get; set; } = new List<Modificator>();
    public List<HeroSkill> Skills { get; set; } = new List<HeroSkill>();

    List<Modificator> AttackModificators
    {
        get
        {
            return Modificators.FindAll(mod => Modificator.OnAttackGroup.Contains(mod.type)); ;
        }
    }

    List<Modificator> HurtModificators
    {
        get
        {
            return Modificators.FindAll(mod => Modificator.OnHurtGroup.Contains(mod.type)); ;
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
            new Modificator
            {
                isPermanent = true,
                type = ModificatorType.DamageCoefReflection,
                activationType = ModificatorActivationType.Tick,
                parametersId = "",
                time = -1,
                value = 2.0,
            }
        });

        new List<HeroSkill>
        {
            new HeroSkill
            {
                ID="heal",
                Countdown = 60,
                Modificators = new List<Modificator>
                {
                   new Modificator {
                isPermanent = false,
                type = ModificatorType.HPCurrentChange,
                activationType = ModificatorActivationType.OneShot,
                parametersId = "",
                time = -1,
                value = 10.0
                   }
                }
            },
            new HeroSkill
            {
                ID="attack",
                Countdown = 60,
                Modificators = new List<Modificator>
                {
                   new Modificator {
                isPermanent = false,
                type = ModificatorType.AttackCoef,
                activationType = ModificatorActivationType.OneShot,
                parametersId = "",
                time = -1,
                value = 0.5
                   }
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
    }

    public double GetDPCDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;

        mods.ForEach(mod =>
        {
            switch (mod.type)
            {
                case ModificatorType.DPCConstAdd:
                    damage += mod.value;
                    break;
                case ModificatorType.DPCCoefAdd:
                    damage += baseDamage * mod.value;
                    break;
            }
        });

        return damage;
    }

    public double GetDPSDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;

        mods.ForEach(mod =>
        {
            switch (mod.type)
            {
                case ModificatorType.DPSConstAdd:
                    damage += mod.value;
                    break;
                case ModificatorType.DPSCoefAdd:
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


        mods.ForEach(mod =>
        {
            switch (mod.type)
            {
                case ModificatorType.DamageConstBlock:
                    block += mod.value;
                    break;
                case ModificatorType.DamageCoefBlock:
                    block += BaseBlock * mod.value;
                    break;
            }
        });

        return damage;
    }

    public double GetReflectionDamage(double baseDamage, List<Modificator> mods)
    {
        
        var damage = 0.0;

        mods.ForEach(mod =>
        {
            switch (mod.type)
            {
                case ModificatorType.DamageConstReflection:
                    damage += mod.value;
                    break;
                case ModificatorType.DamageCoefReflection:
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
        var oneShotMods = Modificators.FindAll(mod=>mod.activationType==ModificatorActivationType.OneShot);
        ReactOnModificators(oneShotMods);
        RemoveModificators(oneShotMods);

        tick += time;
        if(tick >= TICK_TIME)
        {
            tick -= TICK_TIME;

            var tickMods = Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.Tick);
            ReactOnModificators(tickMods);
        }

        UpdateModificators(time);
    }

    public void UpdateModificators(double time)
    {
        Debug.Log(Modificators.Count);
        var tempMods = Modificators.FindAll(mod => !mod.isPermanent);
        tempMods.ForEach(mod => mod.time -= time);
        var modsForRemove = tempMods.FindAll(mod => mod.time <= 0);
        RemoveModificators(modsForRemove);
        Debug.Log(Modificators.Count);
    }

    public void ReactOnModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => ReactOnModificator(mod));
    }

    public void ReactOnModificator(Modificator modificator)
    {
        switch (modificator.type)
        {
            case ModificatorType.DPCBaseConstAdd:
                BaseDamagePerClick += modificator.value;
                break;
            case ModificatorType.DPCBaseCoefAdd:
                BaseDamagePerClick += BaseDamagePerClick * modificator.value;
                break;
            case ModificatorType.DPSBaseConstAdd:
                BaseDamagePerSecond += modificator.value;
                break;
            case ModificatorType.DPSBaseCoefAdd:
                BaseDamagePerSecond += BaseDamagePerSecond * modificator.value;
                break;
            case ModificatorType.HPMaxChange:
                MaximumHealthPoint += modificator.value;
                break;
            case ModificatorType.HPCurrentCoefChange:
                Heal(MaximumHealthPoint * modificator.value);
                break;
            case ModificatorType.HPCurrentChange:
                if (modificator.value < 0)
                {
                    Hurt(modificator.value);
                }
                else
                {
                    Heal(modificator.value);
                }
                break;
            case ModificatorType.AttackConst:
                AdditionalConstAttack?.Invoke(modificator.value, true);
                break;
            case ModificatorType.AttackCoef:
                AdditionalCoefAttack?.Invoke(modificator.value, true);
                break;
        }
    }

    public void PassiveAttack(IEnemy enemy)
    {
        enemy.Hurt(GetDPSDamage(BaseDamagePerSecond, AttackModificators), false);
    }
}
