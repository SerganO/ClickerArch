﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyModel
{
    string Id { get; set; }
    double DurationBetweenAttack { get; set; }
    double Damage { get; set; }
    double MaximumHealthPoint { get; set; }
    double CurrentHealthPoint { get; set; }
    void ConfigureForIdAndLevel(string id, int level);

    List<Effect> Effects { get; set; }

    void AddEffects(List<Effect> effects);
    void RemoveEffects(List<Effect> effects);


    void OnDestroyClear();
}
