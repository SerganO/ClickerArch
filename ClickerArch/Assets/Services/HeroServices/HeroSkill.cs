using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSkill
{
    public string ID;
    public double Countdown;
    public List<Modificator> HeroModificators = new List<Modificator>();

    public List<Effect> HeroEffects = new List<Effect>();
    public List<Effect> EnemyEffects = new List<Effect>();
}
