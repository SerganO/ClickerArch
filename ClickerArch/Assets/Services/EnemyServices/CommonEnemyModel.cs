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

   

    List<Modificator> AttackModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OnAttack);
        }
    }

    List<Modificator> HurtModificators
    {
        get
        {
            return Modificators.FindAll(mod => mod.activationType == ModificatorActivationType.OnHurt);
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

    public double GetDamage(double baseDamage, List<Modificator> mods)
    {
        var damage = baseDamage;
        var dpcMods = mods.FindAll(mod => mod.parameter == ModificatorParameter.DPC && mod.valueType == ModificatorValueType.Current);

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
}
