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

        
        switch (levelId)
        {
            default:
                result.Add("Angel");
                result.Add("Bot");
                result.Add("Slug");
                result.Add("Slug1");
                result.Add("RedHood");
                result.Add("Skeleton2");
                result.Add("Deamon");
                result.Add("inquisitor");
                result.Add("darkDoctor");
                break;
        }
        
        return result;
    }

    public EnemyData GetEnemyDataForIdAndLevel(string id, int level)
    {
        return new EnemyData((int)((Random.value + 0.1) * 100), 1.0, 1, new Drop { xp = 100, gold = 10, Resources = new List<DropResource> { new DropResource { Resource = new Resource { count = 1, rarity = Resource.Rarity.Common }, probability = 75 } } } );
    }

    public Sprite GetSpriteForID(string id)
    {
        //var  a = Resources.Load<Sprite>("Sprites/" + id);
        //Debug.Log(a);
        return Resources.Load<Sprite>("Sprites/" + id);
    }

    public double GetXpForNextLevel(int currentLevel)
    {
        return 1000 + 100 * currentLevel;
    }
}
