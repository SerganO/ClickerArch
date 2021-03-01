using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelModel
{
    string ID { get; set; }
    List<IEnemy> GetEnemies();
    void ConfigureForLevel(int level);
}
