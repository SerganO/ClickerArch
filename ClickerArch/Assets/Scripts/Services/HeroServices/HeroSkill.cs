using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill
{
    public string ID;
    public double Countdown;

    List<Modificator> heroModificators = new List<Modificator>();
    List<Modificator> enemyModificators = new List<Modificator>();
    List<Modificator> sceneModificators = new List<Modificator>();

    List<Effect> heroEffects = new List<Effect>();
    List<Effect> enemyEffects = new List<Effect>();
    List<Effect> sceneEffects = new List<Effect>();

    public List<Modificator> HeroModificators
    {
        get
        {
            var temp = new List<Modificator>();

            heroModificators.ForEach(mod => {
                Debug.Log(mod.ToString());

                temp.Add(mod.Clone());
            });

            return temp;
        }

        set
        {
            heroModificators = value;
        }
    }
    
    public List<Modificator> EnemyModificators
    {
        get
        {
            var temp = new List<Modificator>();

            enemyModificators.ForEach(mod => temp.Add(mod.Clone()));

            return temp;
        }

        set
        {
            enemyModificators = value;
        }
    }

    public List<Modificator> SceneModificators
    {
        get
        {
            var temp = new List<Modificator>();

            sceneModificators.ForEach(mod => temp.Add(mod.Clone()));

            return temp;
        }

        set
        {
            sceneModificators = value;
        }
    }

    public List<Effect> HeroEffects
    {
        get
        {
            var temp = new List<Effect>();

            heroEffects.ForEach(efc => temp.Add(efc.Clone()));

            return temp;
        }

        set
        {
            heroEffects = value;
        }
    }


    public List<Effect> EnemyEffects
    {
        get
        {
            var temp = new List<Effect>();

            enemyEffects.ForEach(efc => temp.Add(efc.Clone()));

            return temp;
        }

        set
        {
            enemyEffects = value;
        }
    }


    public List<Effect> SceneEffects
    {
        get
        {
            var temp = new List<Effect>();

            sceneEffects.ForEach(efc => temp.Add(efc.Clone()));

            return temp;
        }

        set
        {
            sceneEffects = value;
        }
    }
}

public class PassiveHeroSkill: HeroSkill
{
    enum Type
    {
        Base, Advanced
    }

    enum ChangeBase
    {
        CurrentDPC,
        CurrentDPS,
        OnHurt
    }


}
