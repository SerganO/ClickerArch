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

    double BaseDamagePerClickForLevel(int level);
    double BaseDamagePerSecondForLevel(int level);
    double BaseBlockForLevel(int level);
    double BaseReflectForLevel(int level);
    double AdditionalGoldForLevel(int level);
    double AdditionalXPForLevel(int level);
    double MaximumHealthPointForLevel(int level);

    void GetGoodsList(ItemCategory Category, RecipeList completion);
    Recipe GetRecipeForId(string id);
}
