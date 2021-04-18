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

    ILevelHandler handler { get; set; }

    double MaximumHealthPoint { get; set; }
    double BaseDamagePerClick { get; set; }
    double BaseDamagePerSecond { get; set; }
    double BaseBlock { get; set; }
    double BaseReflect { get; set; }

    double CurrentHealthPoint { get; set; }
    double CurrentDamagePerClick { get; }
    double CurrentDamagePerSecond { get; }

    double AdditionalXP { get; set; }
    double AdditionalGold { get; set; }

    List<Modificator> Modificators { get; set; }
    List<Effect> Effects { get; set; }
    List<HeroSkill> ActiveSkills { get; set; }
    List<HeroSkill> PassiveSkills { get; set; }

    void UpdateOnTick(double time);

    void AddModificators(List<Modificator> modificators);
    void RemoveModificators(List<Modificator> modificators);

    void AddEffects(List<Effect> effects);
    void RemoveEffects(List<Effect> effects);

    void Attack(IEnemy enemy);
    void PassiveAttack(IEnemy enemy);
    void Death();
    void Hurt(double damage);
    void Heal(double value);


    void AddGold(double count);
    void AddXP(double count);
}
