using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyModel
{
    string Id { get; set; }
    double DurationBetweenAttack { get; set; }
    double BaseDamage { get; set; }
    double CurrentDamage { get; }
    double MaximumHealthPoint { get; set; }
    double CurrentHealthPoint { get; set; }
    void ConfigureForIdAndLevel(string id, int level);
    Drop drop { get; set; }

    List<Modificator> Modificators { get; set; }
    List<Effect> Effects { get; set; }

    void AddEffects(List<Effect> effects);
    void RemoveEffects(List<Effect> effects);

    void AddModificators(List<Modificator> modificators);
    void RemoveModificators(List<Modificator> modificators);


    void OnDestroyClear();
}
