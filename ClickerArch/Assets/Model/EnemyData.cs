using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public int HP { get; set; }
    public double DurationBetweenAttack { get; set; }
    public int Damage { get; set; }

    public EnemyData(int hp, double duration, int damage)
    {
        HP = hp;
        DurationBetweenAttack = duration;
        Damage = damage;
    }
}
