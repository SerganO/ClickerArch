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

    int CostForBaseDamagePerClickForLevel(int level);
    int CostForBaseDamagePerSecondForLevel(int level);
    int CostForBaseBlockForLevel(int level);
    int CostForBaseReflectForLevel(int level);
    int CostForAdditionalGoldForLevel(int level);
    int CostForAdditionalXPForLevel(int level);
    int CostForMaximumHealthPointForLevel(int level);

    double ValueForParameterForLevel(HeroParameter parameter, int level);

    int CostForParameterForLevel(HeroParameter parameter, int level);
    int CostForClothes(string heroID);
    bool CanUpgradeParameter(HeroParameter parameter);

    void GetGoodsList(ItemCategory Category, RecipeList completion);
    void GetHeroList(StringList completion);
    Recipe GetRecipeForId(string id);
}
