using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonLevelModel : ILevelModel
{
    public string ID { get; set; }

    List<string> enemiesIDs { get; set; } = new List<string>();

    public CommonLevelModel(string id)
    {
        ID = id;
    }


    public void ConfigureForLevel(int level)
    {
        enemiesIDs = Services.GetInstance().GetDataService().GetEnemiesIdsForLevelId(ID);
    }

    public List<IEnemy> GetEnemies()
    {
        List<IEnemy> result = new List<IEnemy>();
        enemiesIDs.ForEach((id) => {
            result.Add(ResourcesObjectSuplier.GetEnemyForID(id));
        });
        return result;
    }
}
