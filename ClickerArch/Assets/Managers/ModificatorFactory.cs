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
            case "adventurer_adventurer":
                return ModificatorForString("AddXP|Immediately|NONE+Const+1+10|Permanent|Remove");
            case "adventurer_zsb_dpc":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+1+1|Time+10+1|Remove");
            case "adventurer_zsb_enemy_damage":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+3+10|Time+10+1|Remove");
            case "arenaWariror_cool_block":
                return ModificatorForString("CurrentBlock|OnHurt|NONE+Const+3+4|Time+10+1|Remove");
            case "arenaWarrior_cool_dpc":
                return ModificatorForString("CurrentDPC|OnAttack|DPC+Coef+-1+4|Time+10+1|Remove");
            case "armorWarrior_block":
                return ModificatorForString("Reflect|OnHurt|NONE+Coef+10+2|Permanent|Remove");
            case "armorWarrior_attack":
                return ModificatorForString("CurrentDPC|Immediately|DPC+Coef+10+1|OneShot|Remove");
            case "assasin_dps":
                return ModificatorForString("CurrentDPS|OnAttack|DPS+Coef+2+1|Time+30+1|Remove");
        }

        return null;
    }


}