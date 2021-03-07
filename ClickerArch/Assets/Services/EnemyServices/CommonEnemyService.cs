using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemyService : IEnemyService
{
    public void ConfigureEnemyForId(IEnemy enemy, string id)
    {
        enemy.ID = id;
        var runtimeAnimator = Resources.Load<RuntimeAnimatorController>("Animators/Enemy/" + id + "AnimatorController");
        var animator = enemy.gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = runtimeAnimator;
    }

    public IEnemy GetEnemyPreset()
    {
        return ResourcesObjectSuplier.GetEnemyPreset();
    }
}
