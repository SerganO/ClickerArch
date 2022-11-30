using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyService
{
    IEnemy GetEnemyPreset();
    void ConfigureEnemyForId(IEnemy enemy, string id);

}
