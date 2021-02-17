using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyService
{
    List<IEnemy> GetEnemiesForLevelId(string id);
}
