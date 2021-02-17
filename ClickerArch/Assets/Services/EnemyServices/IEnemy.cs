using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    IEnemyView GetEnemyView();
    IEnemyModel GetEnemyModel();
}
