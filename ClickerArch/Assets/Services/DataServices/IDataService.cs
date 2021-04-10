using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
    AudioClip GetAudioClipForID(string id);
    Sprite GetSpriteForID(string id);
    List<string> GetEnemiesIdsForLevelId(string levelId);
    EnemyData GetEnemyDataForIdAndLevel(string id, int level);
    double GetXpForNextLevel(int currentLevel);
}
