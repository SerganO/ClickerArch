using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelModel
{
    string ID { get; set; }
    List<string> GetEnemiesIDs();
    void ConfigureForLevel(int level);
}
