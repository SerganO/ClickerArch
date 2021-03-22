using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHero
{
    event VoidFunc OnHurt;
    event VoidFunc OnHeal;
    event VoidFunc OnDie;
    event AttackFunc AdditionalConstAttack;
    event AttackFunc AdditionalCoefAttack;

    double BaseDamagePerClick { get; set; }
    double CurrentDamagePerClick { get; }
    double BaseDamagePerSecond { get; set; }
    double CurrentDamagePerSecond { get; }
    double BaseBlock { get; set; }
    double MaximumHealthPoint { get; set; }
    double CurrentHealthPoint { get; set; }

    List<Modificator> Modificators { get; set; }
    List<HeroSkill> Skills { get; set; }

    void UpdateOnTick(double time);

    void AddModificators(List<Modificator> modificators);
    void RemoveModificators(List<Modificator> modificators);

    void Attack(IEnemy enemy);
    void PassiveAttack(IEnemy enemy);
    void Death();
    void Hurt(double damage);
    void Heal(double value);
}
