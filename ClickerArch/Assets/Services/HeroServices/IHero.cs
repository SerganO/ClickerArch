using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHero
{
    int GetDamageByTap();
    int GetDmagePerSecond();
    int GetHealthPoint();

    List<Modificator> GetModificators();
    void AddModificators(List<Modificator> modificators);
    void RemoveModificators(List<Modificator> modificators);
}
