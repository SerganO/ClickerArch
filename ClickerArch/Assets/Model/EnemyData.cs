using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public int HP { get; set; }
    public double DurationBetweenAttack { get; set; }
    public int Damage { get; set; }

    public Drop Drop { get; set; }

    public EnemyData(int hp, double duration, int damage, Drop drop)
    {
        HP = hp;
        DurationBetweenAttack = duration;
        Damage = damage;
        Drop = drop;
    }
}
