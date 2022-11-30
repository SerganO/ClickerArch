using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyView
{
    void Idle();
    void Attack();
    void Death();
    void Hurt(float ratio, double damage, bool showDamage);
    void UpdateRatio(float ratio);

    void ReactOnEffect(Effect effect);

    void ConfigureForId(string id);
}
