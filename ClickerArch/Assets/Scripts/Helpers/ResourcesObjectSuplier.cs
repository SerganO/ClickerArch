using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesObjectSuplier
{
    public static IEnemy GetEnemyPreset()
    {
        return Resources.Load<IEnemy>("Enemy/enemy");
    }

}
