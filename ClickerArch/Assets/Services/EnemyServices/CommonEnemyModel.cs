﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyModel : IEnemyModel
{
    public string Id { get; set; }
    public double DurationBetweenAttack { get; set; }
    public double Damage { get; set; }
    public double MaximumHealthPoint { get; set; }
    public double CurrentHealthPoint { get; set; }

    public List<Effect> Effects { get; set; } = new List<Effect>();

    public void ConfigureForIdAndLevel(string id, int level)
    {
        Id = id;
        var data = Services.GetInstance().GetDataService().GetEnemyDataForIdAndLevel(id, level);

        MaximumHealthPoint = data.HP;
        CurrentHealthPoint = data.HP;
        DurationBetweenAttack = data.DurationBetweenAttack;
        Damage = data.Damage;
    }

    public void AddEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Effects.Add(efc));

    }

    public void RemoveEffects(List<Effect> effects)
    {
        effects.ForEach(efc => Effects.Remove(efc));

    }

    public void OnDestroyClear()
    {
        Effects = new List<Effect>();
    }
}
