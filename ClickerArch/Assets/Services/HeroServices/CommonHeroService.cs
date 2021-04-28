using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHeroService : IHeroService
{
    public IHero Hero { get; set; } = new CommonHero();

    public void ConfigureForHeroId(string heroID)
    {
        var player = Services.GetInstance().GetPlayer();
        Hero = new CommonHero();
        
        Hero.Modificators = new List<Modificator>();
        Hero.Effects = new List<Effect>();

        Hero.BaseDamagePerClick = player.BaseDamagePerClick;
        Hero.BaseDamagePerSecond = player.BaseDamagePerSecond;
        Hero.CurrentHealthPoint = Hero.MaximumHealthPoint = player.MaximumHealthPoint;
        Hero.BaseBlock = player.BaseBlock;
        Hero.BaseReflect = player.BaseReflect;
        Hero.AdditionalGold = player.AdditionalGold;
        Hero.AdditionalXP = player.AdditionalXP;


        Hero.ActiveSkills = SkillFactory.ActiveSkillsForHeroIdAndLevel(heroID, 0);
        Hero.PassiveSkills = SkillFactory.PassiveSkillsForHeroIdAndLevel(heroID, 0);
    }

}
