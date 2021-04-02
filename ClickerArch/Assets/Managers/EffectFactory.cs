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
            case "arenaWarior_strong":
                return EffectForString("Damage|Immediately|Coef+3+10|OneShot||Remove");
            case "assasin_dps":
                return EffectForString("Color|Immediately|Const+0+1|Time+30+1|color+#00FF00FF|Remove");
        }

        return null;
    }

}