using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesObjectSuplier
{
    public static IEnemy GetEnemyForID(string id)
    {
        return Resources.Load<IEnemy>("Enemies/" + id);
    }

}
