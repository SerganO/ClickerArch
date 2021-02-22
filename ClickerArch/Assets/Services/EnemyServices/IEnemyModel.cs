using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyModel
{
    string Id { get; set; }
    double DurationBetweenAttack { get; set; }
    int Damage { get; set; }
    int MaximumHealthPoint { get; set; }
    int CurrentHealthPoint { get; set; }
    void ConfigureForIdAndLevel(string id, int level);
}
