using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyModel
{
    string GetId();
    double GetDurationBetweenAttack();
    int GetDamage();
    int GetHealthPoint();
    void ConfigureForLevel(int level);
}
