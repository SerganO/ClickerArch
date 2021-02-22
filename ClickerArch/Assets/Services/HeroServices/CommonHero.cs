using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHero : MonoBehaviour, IHero
{
    public int DamageByTap { get; set; }
    public int DamagePerSecond { get; set; }
    public int MaximumHealthPoint { get; set; }
    public int CurrentHealthPoint { get; set; }
    public List<Modificator> Modificators { get; set; }

    public void AddModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Add(mod));
    }

    public void Attack()
    {

    }

    public void Death()
    {

    }

    public void Hurt(int damage)
    {
        CurrentHealthPoint -= damage;
        if(CurrentHealthPoint <= 0)
        {
            Death();
        }
    }

    public void RemoveModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Remove(mod));
    }
}
