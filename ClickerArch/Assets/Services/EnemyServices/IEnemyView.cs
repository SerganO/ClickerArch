using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyView
{
    void Idle();
    void Attack();
    void Death();
    void Hurt(float ratio, int damage, bool showDamage);

    void ConfigureForId(string id);
}
