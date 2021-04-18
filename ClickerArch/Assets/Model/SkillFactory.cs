using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory
{
    public static List<HeroSkill> ActiveSkillsForHeroIdAndLevel(string heroID, int level)
    {
        var resultList = new List<HeroSkill>();

        resultList.Add(new HeroSkill
        {
            ID = "heal",
            Countdown = 30,

            HeroEffects = new List<Effect>
                {
                    EffectFactory.EffectForString("Heal|Immediately|Coef+1+2|OneShot||Remove")
                },
        });
        switch (heroID)
        {
            /////COMMON
            case "Adventurer":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 70,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("adventurer_zsb_dpc"),
                },
                SceneModificators = new List<Modificator>
                {
                      ModificatorFactory.ModificatorForId("adventurer_zsb_enemy_damage")
                }
                    }
                });
                break;
            
            case "ArenaWarrior":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 70,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("arenaWariror_cool_block"),
                    ModificatorFactory.ModificatorForId("arenaWarrior_cool_dpc"),
                },
                    },

                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 25,
                        EnemyEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("arenaWarior_strong")
                        }
                    }
                });
                break;
            case "ArmorWarrior":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 35,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("armorWarrior_attack"),
                },
                    },
                });

                break;
            case "Assassin":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 45,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("assasin_dps"),
                },
                        SceneEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("assasin_dps")
                        }
                    },
                });
                break;
            case "CityBouncer":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 40,

                        EnemyEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("cityBouncer_knob"),
                        }
                    },
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 35,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("cityBouncer_outside"),
                },

                        SceneEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("cityBouncer_outside"),
                        }
                    }
                });

                break;
            case "Cyberclockwerk":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 45,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("cyberclockwerk_cyberimplant"),
                },
                       
                    },
                });
                break;
                
            case "Gunslinger":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 35,

                        EnemyEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("gunslinger_lay"),
                        }
                    },
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 70,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("gunslinger_fire_dpc"),
                    ModificatorFactory.ModificatorForId("gunslinger_fire_dps"),
                },

                    },
                });
                break;
            case "Hastat":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 40,

                        EnemyEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("hastat_lunge"),
                        }
                    },
                });
                break;
            case "LightBandit":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 60,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("lightBandit_naval"),
                }
                    }
                });
                break;
            case "MedievalKing":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 25,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("medievalKing_push"),
                },
                        EnemyEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("medievalKing_push")
                        }
                    }
                });
                break;
            case "Ninja":
                resultList.AddRange(new List<HeroSkill> {
                    new HeroSkill
                    {
                        ID = "attack",
                        Countdown = 25,
                        HeroModificators = new List<Modificator>
                {
                    ModificatorFactory.ModificatorForId("ninja_mask"),
                },
                        EnemyEffects = new List<Effect>
                        {
                            EffectFactory.EffectForId("ninja_mask")
                        }
                    }
                });
                break;
            case "Squire":
                break;
                /////RARE

            case "Blacksmith":
                break;
            case "BlueKing":
                break;
            case "GothicHero":
                break;
            case "HeroKnight":
                break;
            case "Janissary":
                break;
            case "Archer":
                break;
            case "Monk":
                break;
            case "Ranger":
                break;
            case "Robot":
                break;
            case "RoyalKnight":
                break;
            case "Samurai":
                break;
            case "Striker":
                break;
            case "Wizard":
                break;
        }

        return resultList;
    }

    public static List<HeroSkill> PassiveSkillsForHeroIdAndLevel(string heroID, int level)
    {
        var resultList = new List<HeroSkill>();
        switch (heroID)
        {
            case "Adventurer":
                resultList.AddRange(new List<HeroSkill>
                {
                    new HeroSkill
                    {
                        HeroModificators = new List<Modificator>
                        {
                            ModificatorFactory.ModificatorForId("adventurer_adventurer")
                        }
                    }
                });
                break;
            case "Archer":
                break;
            case "ArenaWarrior":
                break;
            case "ArmorWarrior":
                resultList.AddRange(new List<HeroSkill>
                {
                    new HeroSkill
                    {
                        HeroModificators = new List<Modificator>
                        {
                            ModificatorFactory.ModificatorForId("armorWarrior_block")
                        }
                    }
                });
                break;
            case "Assassin":
                break;
            case "Blacksmith":
                break;
            case "BlueKing":
                break;
            case "Cyberclockwerk":
                break;
            case "GothicHero":
                break;
            case "Gunslinger":
                break;
            case "Hastat":
                break;
            case "HeroKnight":
                break;
            case "Janissary":
                break;
            case "LightBandit":
                resultList.AddRange(new List<HeroSkill>
                {
                    new HeroSkill
                    {
                        HeroModificators = new List<Modificator>
                        {
                            ModificatorFactory.ModificatorForId("lightBandit_gold")
                        }
                    }
                });
                break;
            case "MedievalKing":
                resultList.AddRange(new List<HeroSkill>
                {
                    new HeroSkill
                    {
                        HeroModificators = new List<Modificator>
                        {
                            ModificatorFactory.ModificatorForId("medievalKing_passive_debat_xp"),
                            ModificatorFactory.ModificatorForId("medievalKing_passive_debat_gold"),
                            ModificatorFactory.ModificatorForId("medievalKing_passive_debat_dpc"),
                        }
                    }
                });
                break;
            case "MedievalWarrior":
                break;
            case "Monk":
                break;
            case "Ninja":
                break;
            case "Ranger":
                break;
            case "Robot":
                break;
            case "RoyalKnight":
                break;
            case "Samurai":
                break;
            case "Squire":
                break;
            case "Striker":
                break;
            case "Wizard":
                break;
        }

        return resultList;
    }

}
