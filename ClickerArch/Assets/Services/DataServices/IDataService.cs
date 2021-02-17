using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService
{
    AudioClip GetAudioClipForID(string id);
    Sprite GetSpriteForID(string id);
    IEnemy GetEnemyForID(string id);
    List<string> GetEnemiesIdsForLevelId(string levelId);
}
