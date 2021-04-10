using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory
{

    //PARAMETER|ACTIVATION_TYPE|CHANGE_TYPE|VALUE_MAIN_PART|VALUE_SIZE_PART|TIME_MAIN_PART|TIME_SIZE_PART|END_TYPE=ATTR_KEY+ATTR_VALUE!REPLACE

    // Heal|Immediately|Const+10+1|Time+10+1|additional|Remove

    public static Effect EffectForString(string rawString)
    {
        return new Effect(rawString);
    }

    public static Effect EffectForId(string Id)
    {
        switch (Id)
        {
            //===========COMMON===========
            case "arenaWarior_strong":
                return EffectForString("ConstDamage|Immediately|Coef+3+10|OneShot||Remove");

            case "assasin_dps":
                return EffectForString("Color|Immediately|Const+0+1|Time+30+1|color+#00FF00FF|Remove");

            case "cityBouncer_knob":
                return EffectForString("Stun|Immediately|Const+0+1|Time+10+1||Remove");
            case "cityBouncer_outside":
                return EffectForString("Color|Immediately|Const+0+1|Time+20+1|color+#FF0000FF|Remove");

            case "gunslinger_lay":
                return EffectForString("Stun|Immediately|Const+0+1|Time+7+1||Remove");

            case "hastat_lunge":
                return EffectForString("ConstDamage|Immediately|Coef+3+10|OneShot||Remove");

            case "medievalKing_push":
                return EffectForString("ConstDamage|Immediately|Coef+1+2|OneShot||Remove");

            case "ninja_mask":
                return EffectForString("Stun|Immediately|Const+0+1|Time+5+1||Remove");
            //===========RARE===========

            case "archer_mood_color":
                return EffectForString("Color|Immediately|Const+0+1|Time+20+1|color+#800000FF|Remove");
            case "archer_mood_damage":
                return EffectForString("OponentDPCDamage|Immediately|Coef+28+10|OneShot||Remove");
        }

        return null;
    }

}