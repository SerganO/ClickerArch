using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectActivationType
{
    OneShot, Tick
}

public enum EffectType
{
    Damage,
    Heal,
    Stun,
    Color
}

public enum EffectValueChangeType
{
    Const, Coef, AddConst, AddCoef
}

public enum EffectEndType
{
    OneShot, Permanent, Time, Replacing
}

public class Effect
{
    //EFFECT_TYPE===ACTIVATION_TYPE===CHANGE_TYPE===VALUE_MAIN_PART===VALUE_SIZE_PART===TIME_MAIN_PART===TIME_SIZE_PART===END_TYPE||REPLACE

    public EffectType parameter;
    public EffectActivationType activationType;
    public EffectValueChangeType changeType;
    public double value;
    public double time;
    public EffectEndType endType;
    public string replaceString;

    public Dictionary<string, string> additionalParametrs;


    public bool Check()
    {
        if (NeedReplace())
        {
            return Replace();
        }
        else
        {
            return false;
        }
    }

    private bool NeedReplace()
    {
        switch (endType)
        {
            case EffectEndType.OneShot:
                return true;
            case EffectEndType.Permanent:
                return false;
            case EffectEndType.Time:
                return CheckTime();
            case EffectEndType.Replacing:
                return CheckTime();
        }
        return true;
    }

    private bool CheckTime()
    {
        return time <= 0;
    }

    public bool Replace()
    {
        if (endType == EffectEndType.Replacing && CheckTime()) return true;
        if (replaceString == "")
        {
            return true;
        }
        else
        {

            var temp = EffectFactory.EffectForString(replaceString);

            parameter = temp.parameter;
            activationType = temp.activationType;
            endType = temp.endType;


            switch (temp.changeType)
            {
                case EffectValueChangeType.AddConst:
                    value += temp.value;
                    break;
                case EffectValueChangeType.AddCoef:
                    value += value * temp.value;
                    break;
                default:
                    value = temp.value;
                    changeType = temp.changeType;
                    replaceString = temp.replaceString;
                    time = temp.time;
                    additionalParametrs = temp.additionalParametrs;
                    break;
            }

            return false;
        }
    }

    public Effect Clone()
    {
        return new Effect()
        {
            parameter = parameter,
            activationType = activationType,
            changeType = changeType,
            value = value,
            time = time,
            endType = endType,
            replaceString = replaceString,

            additionalParametrs = additionalParametrs
        };
    }

    public override string ToString()
    {
        return base.ToString() + ": " + parameter + " " + activationType + " " + changeType + " " + " " + value + " " + time + " " + endType + " " + additionalParametrs;
    }
}
