using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHero : IHero
{
    double TICK_TIME = 1.0;
    double tick = 0;

    public event VoidFunc OnHurt;
    public event VoidFunc OnDie;
    public event AttackFunc AdditionalConstAttack;
    public event AttackFunc AdditionalCoefAttack;
    public event VoidFunc OnHeal;

    public double AdditionalXP { get; set; }
    public double AdditionalGold { get; set; }

    public double MaximumHealthPoint { get; set; }
    public double BaseDamagePerClick { get; set; }
    public double BaseDamagePerSecond { get; set; }
    public double BaseBlock { get; set; }
    public double BaseReflect { get; set; }

    public double CurrentHealthPoint { get; set; }

    public List<Modificator> Modificators { get; set; } = new List<Modificator>();
    public List<Effect> Effects { get; set; } = new List<Effect>();
    public List<HeroSkill> ActiveSkills { get; set; } = new List<HeroSkill>();
    public List<HeroSkill> PassiveSkills { get; set; } = new List<HeroSkill>();

    public ILevelHandler handler { get; set; }


    double GetValue(Modificator.Parameter parameter)
    {
        switch (parameter)
        {
            case Modificator.Parameter.NONE:
                break;
            case Modificator.Parameter.HP:
                return MaximumHealthPoint;
            case Modificator.Parameter.DPC:
                return BaseDamagePerClick;
            case Modificator.Parameter.DPS:
                return BaseDamagePerSecond;
            case Modificator.Parameter.Reflect:
                return BaseReflect;
            case Modificator.Parameter.Block:
                return BaseBlock;
            case Modificator.Parameter.CurrentHP:
                return CurrentHealthPoint;
            case Modificator.Parameter.CurrentDPC:
                return CurrentDamagePerClick;
            case Modificator.Parameter.CurrentDPS:
                return CurrentDamagePerSecond;
            case Modificator.Parameter.CurrentReflect:
                break;
            case Modificator.Parameter.CurrentBlock:
                break;
            case Modificator.Parameter.AdditionalXP:
                break;
            case Modificator.Parameter.AdditionalGold:
                break;
            case Modificator.Parameter.EnemyHP:
                return handler.GetCommonParameters(parameter);
            default:
                break;
        }

        return 0;
    }


    List<Modificator> AttackModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.OnAttack); ;
        }
    }

    List<Modificator> HurtModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.OnHurt); ;
        }
    }

    List<Modificator> StartModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.OnStart); ;
        }
    }

    List<Modificator> TickModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.Tick); ;
        }
    }

    List<Modificator> OneShotModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.Immediately); ;
        }
    }


    List<Effect> TickEffects
    {
        get
        {
            return Effects.FindAll(efc => efc.activationType == Effect.ActivationType.Tick); ;
        }
    }

    List<Effect> OneShotEffects
    {
        get
        {
            return Effects.FindAll(efc => efc.activationType == Effect.ActivationType.Immediately); ;
        }
    }

    List<Modificator> dpcMods
    {
        get
        {
            return Modificators.FindAll(mod => mod.parameter == Modificator.Parameter.CurrentDPC);
        }
    }

    List<Modificator> dpsMods
    {
        get
        {
            return Modificators.FindAll(mod => mod.parameter == Modificator.Parameter.CurrentDPS);
        }
    }

    public double CurrentDamagePerClick
    {
        get
        {
            return GetDPCDamage(BaseDamagePerClick, dpcMods);
        }
    }

    public double CurrentDamagePerSecond
    {
        get
        {
            return GetDPSDamage(BaseDamagePerSecond, dpsMods);
        }
    }

    public CommonHero()
    {
        
    }


    public void StartSetup()
    {
        PassiveSkills.ForEach((skill) =>
        {
            Modificators.AddRange(skill.HeroModificators);



        });

        ReactOnModificators(StartModificators);
        UpdateModificators(0);

    }


    public void AddModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Add(mod));

    }


    public void AddEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Effects.Add(efc));

    }

    public void RemoveEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Effects.Remove(efc));

    }

    public void Attack(IEnemy enemy)
    {
        var damage = GetDPCDamage(BaseDamagePerClick, dpcMods);
        enemy.Hurt(damage);
        dpcMods.ForEach(mod=>mod.OnUseChange());
    }

    public double GetDPCDamage(double baseDamage, List<Modificator> dpcMods)
    {
        var damage = baseDamage;
        

        dpcMods.ForEach(mod =>
        {
            mod.values.ForEach(value =>
            {
                switch (value.changeType)
                {
                    case Modificator.ChangeValue.ValueChangeType.Const:
                        damage += value.value;
                        break;
                    case Modificator.ChangeValue.ValueChangeType.Coef:
                        damage += GetValue(value.baseParameter) * value.value;
                        break;
                }
            });
        });

        return damage;
    }

    public double GetDPSDamage(double baseDamage, List<Modificator> dpsMods)
    {
        var damage = baseDamage;

        dpsMods.ForEach(mod =>
        {
            mod.values.ForEach(value =>
            {
                switch (value.changeType)
                {
                    case Modificator.ChangeValue.ValueChangeType.Const:
                        damage += value.value;
                        break;
                    case Modificator.ChangeValue.ValueChangeType.Coef:
                        damage += GetValue(value.baseParameter) * value.value;
                        break;
                }
            });
        });

        return damage;
    }

    public double GetAfterBlockDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;
        var block = BaseBlock;


        var blockMods = mods.FindAll(mod => mod.parameter == Modificator.Parameter.CurrentBlock);

        blockMods.ForEach(mod =>
        {
            mod.values.ForEach(value =>
            {
                switch (value.changeType)
                {
                    case Modificator.ChangeValue.ValueChangeType.Const:
                        block += value.value;
                        break;
                    case Modificator.ChangeValue.ValueChangeType.Coef:
                        block += GetValue(value.baseParameter) * value.value;
                        break;
                }
            });
        });

        return Mathf.Max(0, (float)(damage - damage * block));
    }

    public double GetReflectionDamage(double baseDamage, List<Modificator> mods)
    {
        
        var damage = baseDamage * BaseReflect;

        var reflectMods = mods.FindAll(mod => mod.parameter == Modificator.Parameter.Reflect);

        reflectMods.ForEach(mod =>
        {
            mod.values.ForEach(value =>
            {
                Debug.Log(value.changeType + " " + value.value);
                switch (value.changeType)
                {
                    case Modificator.ChangeValue.ValueChangeType.Const:
                        damage += value.value;
                        break;
                    case Modificator.ChangeValue.ValueChangeType.Coef:
                        damage += baseDamage * value.value;
                        break;
                }
            });
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
        Debug.Log("Getted damage: " + gettedDamage);
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
        ReactOnModificators(OneShotModificators);
        ReactOnEffects(OneShotEffects);

        tick += time;
        if(tick >= TICK_TIME)
        {
            tick -= TICK_TIME;
            ReactOnModificators(TickModificators);
            ReactOnEffects(TickEffects);
        }

        UpdateModificators(time);
        UpdateEffects(time);
    }

    public void UpdateModificators(double time)
    {
        
        var tempMods = Modificators.FindAll(mod => mod.checker.endCheckType != Modificator.CheckObject.EndCheckType.Permanent);

        tempMods.ForEach(mod => {
            mod.UpdateTime(time);
        });

        var modsForRemove = Modificators.FindAll(mod => mod.Check());
        RemoveModificators(modsForRemove);
        
    }

    public void UpdateEffects(double time)
    {

        var tempEfc = Effects.FindAll(efc => efc.checker.endCheckType != Effect.CheckObject.EndCheckType.Permanent);
        tempEfc.ForEach(mod => mod.UpdateTime(time));


        var efcsForRemove = Effects.FindAll(efc => efc.Check());
        RemoveEffects(efcsForRemove);

    }



    public void PassiveAttack(IEnemy enemy)
    {
        if (enemy == null) return;
        enemy.Hurt(GetDPSDamage(BaseDamagePerSecond, dpsMods), false);
        dpsMods.ForEach(mod => mod.OnUseChange());
    }

    public void ReactOnModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Debug.Log("xp " + mod.parameter));
        modificators.ForEach(mod => ReactOnModificator(mod));
        modificators.ForEach(mod => mod.OnUseChange());
    }

    public void ReactOnModificator(Modificator modificator)
    {
        double changeValue = 0;

        modificator.values.ForEach(value =>
        {
            switch (value.changeType)
            {
                case Modificator.ChangeValue.ValueChangeType.Const:
                    changeValue += value.value;
                    break;
                case Modificator.ChangeValue.ValueChangeType.Coef:
                    changeValue += GetValue(value.baseParameter) * value.value;
                    break;
            }
        });

        switch (modificator.parameter)
        {
            case Modificator.Parameter.NONE:
                break;
            case Modificator.Parameter.HP:
                MaximumHealthPoint += changeValue;
                break;
            case Modificator.Parameter.DPC:
                BaseDamagePerClick += changeValue;
                break;
            case Modificator.Parameter.DPS:
                BaseDamagePerSecond += changeValue;
                break;
            case Modificator.Parameter.Reflect:
                BaseReflect += changeValue;
                break;
            case Modificator.Parameter.Block:
                BaseBlock += changeValue;
                break;
            case Modificator.Parameter.CurrentHP:
                CurrentHealthPoint += changeValue;
                break;
            case Modificator.Parameter.CurrentDPC:
                AdditionalConstAttack(changeValue, true);
                break;
            case Modificator.Parameter.CurrentDPS:
                break;
            case Modificator.Parameter.CurrentReflect:
                break;
            case Modificator.Parameter.CurrentBlock:
                break;
            case Modificator.Parameter.AdditionalXP:
                AdditionalXP += changeValue;
                break;
            case Modificator.Parameter.AdditionalGold:
                AdditionalGold += changeValue;
                break;
            case Modificator.Parameter.Gold:
                AddGold(changeValue);
                break;
            case Modificator.Parameter.XP:
                AddXP(changeValue);
                break;
        }
    }

    public void ReactOnEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Debug.Log(efc));
        effects.ForEach(efc => ReactOnEffect(efc));
    }

    public void ReactOnEffect(Effect effect)
    {
        double constPart = 0;
        double coefPart = 0;

        effect.values.ForEach(value=>
        {
            switch (value.changeType)
            {
                case Effect.ChangeValue.ValueChangeType.Const:
                    constPart += value.value;
                    break;
                case Effect.ChangeValue.ValueChangeType.Coef:
                    coefPart += value.value;
                    break;
            }
        });


        switch (effect.type)
        {
            case Effect.Type.NONE:
                break;
            case Effect.Type.ConstDamage:
                Hurt(constPart + coefPart * MaximumHealthPoint);
                break;
            case Effect.Type.Heal:
                Heal(constPart + coefPart * MaximumHealthPoint);
                break;
            case Effect.Type.Stun:
                break;
            case Effect.Type.Color:
                break;
        }

    }

    public void AddGold(double count)
    {
        Debug.Log(count);
        if(count >= 0)
        {
            Services.GetInstance().GetPlayer().AddGold((count + count * AdditionalGold));
        } else
        {
            Services.GetInstance().GetPlayer().RemoveGold(-count);
        }

    }

    public void AddXP(double count)
    {
        var xp = count + count * AdditionalXP;
        Debug.Log("XP: " + xp);
        Services.GetInstance().GetPlayer().AddXP(xp);
    }
}
