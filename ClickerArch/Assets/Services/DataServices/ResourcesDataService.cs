using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesDataService : IDataService
{
    public AudioClip GetAudioClipForID(string id)
    {
        return Resources.Load("AudioClips/" + id) as AudioClip;
    }

    public List<string> GetEnemiesIdsForLevelId(string levelId)
    {
        var result = new List<string>();

        result.Add("test_enemy");
        switch(levelId)
        {

        }
        
        return result;
    }

    public EnemyData GetEnemyDataForIdAndLevel(string id, int level)
    {
        return new EnemyData(100, 1.0, 1);
    }

    public Sprite GetSpriteForID(string id)
    {
        return Resources.Load("Sprites/" + id) as Sprite;
    }
}
