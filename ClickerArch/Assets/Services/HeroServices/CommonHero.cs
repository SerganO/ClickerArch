using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHero : IHero
{
    private int MockDPT = 9;

    public event VoidFunc OnHurt;
    public event VoidFunc OnDie;

    public int DamageByTap { get; set; }
    public int DamagePerSecond { get; set; }
    public int MaximumHealthPoint { get; set; }
    public int CurrentHealthPoint { get; set; }
    public List<Modificator> Modificators { get; set; }

    public CommonHero()
    {
        DamageByTap = MockDPT;
        CurrentHealthPoint = 20;
        MaximumHealthPoint = 20;
    }

    public void AddModificators(List<Modificator> modificators)
    {
        modificators.ForEach(mod => Modificators.Add(mod));
    }

    public void Attack()
    {

    }

    public void Death()
    {
        OnDie?.Invoke();
    }

    public void Hurt(int damage)
    {
        CurrentHealthPoint -= damage;
        OnHurt?.Invoke();
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
