using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyModel : IEnemyModel
{
    public string Id { get; set; }
    public double DurationBetweenAttack { get; set; }
    public int Damage { get; set; }
    public int MaximumHealthPoint { get; set; }
    public int CurrentHealthPoint { get; set; }

    public void ConfigureForIdAndLevel(string id, int level)
    {
        Id = id;
        var data = Services.GetInstance().GetDataService().GetEnemyDataForIdAndLevel(id, level);

        MaximumHealthPoint = data.HP;
        CurrentHealthPoint = data.HP;
        DurationBetweenAttack = data.DurationBetweenAttack;
        Damage = data.Damage;
    }

}
