using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificatorFactory
{
    //PARAMETER===VALUE_TYPE===ACTIVATION_TYPE===CHANGE_TYPE===VALUE_MAIN_PART===VALUE_SIZE_PART===TIME_MAIN_PART===TIME_SIZE_PART===END_TYPE||REPLACE

    // CurrentDPC|OnAttack|NONE+Const+10+1+3+2|Time+10+1|Remove
    public static Modificator ModificatorForString(string rawString)
    {
        return new Modificator(rawString);

    }

    public static Modificator ModificatorForId(string Id)
    {
        switch(Id)
        {
            //===========COMMON===========
            case "adventurer_adventurer":
                return ModificatorForString("AdditionalXP|OnStart|NONE+Const+1+10|Permanent|Remove");
            case "adventurer_zsb_dpc":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Time+10+1|Remove");
            case "adventurer_zsb_enemy_damage":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+3+10|Time+10+1|Remove");

            case "arenaWariror_cool_block":
                return ModificatorForString("CurrentBlock|OnHurt|NONE+Const+3+4|Time+10+1|Remove");
            case "arenaWarrior_cool_dpc":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+-1+4|Time+10+1|Remove");

            case "armorWarrior_block":
                return ModificatorForString("Reflect|OnHurt|NONE+Coef+1+2|Permanent|Remove");
            case "armorWarrior_attack":
                return ModificatorForString("CurrentDPC|Immediately|DPC+Coef+10+1|OneShot|Remove");

            case "assasin_dps":
                return ModificatorForString("CurrentDPS|OnAttack|DPS+Coef+2+1|Time+30+1|Remove");

            case "cityBouncer_outside":
                return ModificatorForString("CurrentDPS|OnAttack|DPS+Coef+3+2|Time+20+1|Remove");

            case "cyberclockwerk_cyberimplant":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Time+20+1|Remove");

            case "gunslinger_fire_dpc":
                return ModificatorForString("CurrentDPS|OnAttack|DPS+Coef+2+10|Time+15+1|Remove");
            case "gunslinger_fire_dps":
                return ModificatorForString("CurrentDPS|OnAttack|DPC+Coef+12+10|Time+15+1|Remove");

            case "lightBandit_naval":
                return ModificatorForString("CurrentDPS|OnAttack|DPC+Coef+5+1|Time+20+1|Remove");
            case "lightBandit_gold":
                return ModificatorForString("AdditionalGold|OnStart|NONE+Const+1+10|OneShot|Remove");

            case "medievalKing_push":
                return ModificatorForString("Gold|Immediately|EnemyHP+Coef+-5+100|OneShot|Remove");

            case "medievalKing_passive_debat_xp":
                return ModificatorForString("AdditionalGold|OnStart|NONE+Const+7+100|OneShot|Remove");
            case "medievalKing_passive_debat_gold":
                return ModificatorForString("AdditionalXP|OnStart|NONE+Const+7+100|OneShot|Remove");
            case "medievalKing_passive_debat_dpc":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+-13+100|Permanent|Remove");

            case "ninja_mask":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+2|Time+5+1|Remove");
            //===========RARE===========
            case "archer_mood":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+-17+100|Time+10+1|Remove");
        }

        return null;
    }


}