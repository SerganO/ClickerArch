using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyView
{
    void Idle();
    void Attack();
    void Death();
    void Hurt();

    void ConfigureForId(string id);
}
