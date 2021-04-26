using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHeroService : IHeroService
{
    public IHero Hero { get; set; } = new CommonHero();

    public void ConfigureForHeroId(string heroID)
    {
        Hero = new CommonHero();
        Hero.Modificators = new List<Modificator>();
        Hero.Effects = new List<Effect>();


        Hero.ActiveSkills = SkillFactory.ActiveSkillsForHeroIdAndLevel(heroID, 0);
        Hero.PassiveSkills = SkillFactory.PassiveSkillsForHeroIdAndLevel(heroID, 0);
    }

}
