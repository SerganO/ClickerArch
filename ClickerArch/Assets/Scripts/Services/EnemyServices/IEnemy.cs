﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy: MonoBehaviour
{
    public string ID { get; set; }
    public abstract event VoidFunc onDie;

    public ILevelHandler handler;

    public abstract IEnemyView GetEnemyView();
    public abstract IEnemyModel GetEnemyModel();


    public abstract void Idle();
    public abstract void Attack();
    public abstract void Death();
    public abstract void Hurt(double damage, bool isManualDamage = true);
    public abstract void Heal(double value);

    public abstract void ConfigureForLevel(int level);
}
