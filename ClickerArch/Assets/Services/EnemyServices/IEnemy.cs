using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    IEnemyView GetEnemyView();
    IEnemyModel GetEnemyModel();

    void Idle();
    void Attack();
    void Death();
    void Hurt(int damage, bool isManualDamage = true);

    void ConfigureForLevel(int level);
}
