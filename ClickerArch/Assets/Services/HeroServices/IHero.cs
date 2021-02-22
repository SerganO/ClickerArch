using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHero
{
    int DamageByTap { get; set; }
    int DamagePerSecond { get; set; }
    int MaximumHealthPoint { get; set; }
    int CurrentHealthPoint { get; set; }

    List<Modificator> Modificators { get; set; }

    void AddModificators(List<Modificator> modificators);
    void RemoveModificators(List<Modificator> modificators);

    void Attack();
    void Death();
    void Hurt(int damage);
}
