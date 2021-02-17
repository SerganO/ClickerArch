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

        switch(levelId)
        {

        }
        
        return result;
    }

    public IEnemy GetEnemyForID(string id)
    {
        return Resources.Load("Enemies/" + id) as IEnemy;
    }

    public Sprite GetSpriteForID(string id)
    {
        return Resources.Load("Sprites/" + id) as Sprite;
    }
}
