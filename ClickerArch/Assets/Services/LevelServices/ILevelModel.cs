using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelModel
{
    string GetId();
    List<IEnemy> GetEnemies();
    void ConfigureForLevel(int level);
}
