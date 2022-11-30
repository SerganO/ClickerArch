using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyModel : IEnemyModel
{
    public string Id { get; set; }
    public double DurationBetweenAttack { get; set; }


    public double BaseDamage { get; set; }
    public double CurrentDamage {
        get
        {
            return GetDamage(BaseDamage, AttackModificators);
        }
    }
    public double MaximumHealthPoint { get; set; }
    public double CurrentHealthPoint { get; set; }

    public List<Modificator> Modificators { get; set; } = new List<Modificator>();
    public List<Effect> Effects { get; set; } = new List<Effect>();


    public Drop drop { get; set; }


    List<Modificator> AttackModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.OnAttack);
        }
    }

    List<Modificator> HurtModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == Modificator.ActivationType.OnHurt);
        }
    }

    public void ConfigureForIdAndLevel(string id, int level)
    {
        Id = id;
        var data = Services.GetInstance().GetDataService().GetEnemyDataForIdAndLevel(id, level);

        MaximumHealthPoint = data.HP;
        CurrentHealthPoint = data.HP;
        DurationBetweenAttack = data.DurationBetweenAttack;
        BaseDamage = data.Damage;
        drop = data.Drop;
    }

    public void AddEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Effects.Add(efc));

    }

    public void RemoveEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Effects.Remove(efc));

    }

    public void AddModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Add(mod));

    }

    public void RemoveModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Remove(mod));

    }

    public void OnDestroyClear()
    {
        Effects = new List<Effect>();
    }

    double GetValue(Modificator.Parameter parameter)
    {
        switch (parameter)
        {
            case Modificator.Parameter.NONE:
                break;
            case Modificator.Parameter.HP:
                return MaximumHealthPoint;
            case Modificator.Parameter.DPC:
                return BaseDamage;
            case Modificator.Parameter.DPS:
                break;
            case Modificator.Parameter.Reflect:
                break;
            case Modificator.Parameter.Block:
                break;
            case Modificator.Parameter.CurrentHP:
                return CurrentHealthPoint;
            case Modificator.Parameter.CurrentDPC:
                return CurrentDamage;
            case Modificator.Parameter.CurrentDPS:
                break;
            case Modificator.Parameter.CurrentReflect:
                break;
            case Modificator.Parameter.CurrentBlock:
                break;
        }

        return 0;
    }

    public double GetDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;
        var dpcMods = mods.FindAll(mod => mod.parameter == Modificator.Parameter.CurrentDPC);

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
}
