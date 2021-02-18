using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyModel
{
    string GetId();
    double GetDurationBetweenAttack();
    int GetDamage();
    int GetHealthPoint();
    void ConfigureForIdAndLevel(string id, int level);
}
