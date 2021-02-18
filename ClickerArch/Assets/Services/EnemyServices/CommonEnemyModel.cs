using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyModel : IEnemyModel
{
    public string id;
    public int hp;
    public int damage;
    public double durationBetweenAttack;

    public void ConfigureForIdAndLevel(string id, int level)
    {
        this.id = id;
        var data = Services.GetInstance().GetDataService().GetEnemyDataForIdAndLevel(id, level);

        hp = data.HP;
        durationBetweenAttack = data.DurationBetweenAttack;
        damage = data.Damage;

    }

    public int GetDamage()
    {
        return damage;
    }

    public double GetDurationBetweenAttack()
    {
        return durationBetweenAttack;
    }

    public int GetHealthPoint()
    {
        return hp;
    }

    public string GetId()
    {
        return id;
    }
}
