using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyService : IEnemyService
{
    public List<IEnemy> GetEnemiesForLevelId(string id)
    {
        var res = new List<IEnemy>();
        var ids = Services.GetInstance().GetDataService().GetEnemiesIdsForLevelId(id);

        foreach(var _id in ids)
        {
            res.Add(ResourcesObjectSuplier.GetEnemyForID(_id));
        }

        return res;
    }
}
