using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ModificatorValueType
{
    Base,
    Current
}

public enum ModificatorParameter {
    HP,
    DPC,
    DPS,
    Reflect,
    Block,

}

public enum ModificatorActivationType
{
    OnStart, Tick, OnAttack, OnHurt, OneShot
}

public enum ModificatorValueChangeType
{
    Const, Coef, AddConst, AddCoef
}

public enum ModificatorEndType
{
    OneShot, Permanent, Time, Replacing
}




public class ModificatorFactory
{
    //PARAMETER===VALUE_TYPE===ACTIVATION_TYPE===CHANGE_TYPE===VALUE_MAIN_PART===VALUE_SIZE_PART===TIME_MAIN_PART===TIME_SIZE_PART===END_TYPE||REPLACE

    public static Modificator ModificatorForString(string rawString)
    {
        if(rawString == "")
        {
            return null;
        }


        string mainPart = "";
        string replacePart = "";

        int index = rawString.IndexOf('|');

        if(index != - 1)
        {
            mainPart = rawString.Substring(0, index);
            replacePart = rawString.Substring(index + 1);
        } else
        {
            mainPart = rawString;
        }

        Debug.Log(mainPart);
        Debug.Log(replacePart);

        var parts = mainPart.Split('=');


        ModificatorParameter parameter = ParametrForString(parts[0]);
        ModificatorValueType valueType = ValueTypeForString(parts[1]);
        ModificatorActivationType activationType = ActivationTypeForString(parts[2]);
        ModificatorValueChangeType changeType = ChangeTypeForString(parts[3]);
        int valueMainPart = 0;
        int valueSizePart = 0;
        int.TryParse(parts[4], out valueMainPart);
        int.TryParse(parts[5], out valueSizePart);
        double value = (double)valueMainPart / valueSizePart;
        int timeMainPart = 0;
        int timeSizePart = 0;
        int.TryParse(parts[6], out timeMainPart);
        int.TryParse(parts[7], out timeSizePart);
        double time = (double)timeMainPart / timeSizePart;
        ModificatorEndType endType = EndTypeForString(parts[8]);
        Modificator result = new Modificator
        {
            parameter = parameter,
            valueType = valueType,
            activationType = activationType,
            changeType = changeType,
            value = value,
            time = time,
            endType = endType
        };

        result.replaceString = replacePart;

        return result;
    }

    static ModificatorParameter ParametrForString(string str)
    {
        return ((ModificatorParameter)System.Enum.Parse(typeof(ModificatorParameter), str));
    }

    static ModificatorActivationType ActivationTypeForString(string str)
    {
        return ((ModificatorActivationType)System.Enum.Parse(typeof(ModificatorActivationType), str));
    }

    static ModificatorValueChangeType ChangeTypeForString(string str)
    {
        return ((ModificatorValueChangeType) System.Enum.Parse(typeof(ModificatorValueChangeType), str));
    }

    static ModificatorValueType ValueTypeForString(string str)
    {
        return ((ModificatorValueType)System.Enum.Parse(typeof(ModificatorValueType), str));
    }

    static ModificatorEndType EndTypeForString(string str)
    {
        return ((ModificatorEndType)System.Enum.Parse(typeof(ModificatorEndType), str));
    }

}


public class Modificator
{
    public ModificatorParameter parameter;
    public ModificatorActivationType activationType;
    public ModificatorValueChangeType changeType;
    public ModificatorValueType valueType;
    public double value;
    public double time;
    public ModificatorEndType endType;
    public string replaceString;

    public bool Check()
    {
        if(NeedReplace())
        {
            return Replace();
        } else
        {
            return false;
        }
    }

    private bool NeedReplace()
    {
        switch (endType)
        {
            case ModificatorEndType.OneShot:
                return true;
            case ModificatorEndType.Permanent:
                return false;
            case ModificatorEndType.Time:
                return CheckTime();
            case ModificatorEndType.Replacing:
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
        if (endType == ModificatorEndType.Replacing && CheckTime()) return true;
        if (replaceString == "")
        {
            return true;
        }
        else
        {
            
            var temp = ModificatorFactory.ModificatorForString(replaceString);

            parameter = temp.parameter;
            valueType = temp.valueType;
            activationType = temp.activationType;
            endType = temp.endType;
            

            switch (temp.changeType)
            {
                case ModificatorValueChangeType.AddConst:
                    value += temp.value;
                    break;
                case ModificatorValueChangeType.AddCoef:
                    value += value * temp.value;
                    break;
                default:
                    value = temp.value;
                    changeType = temp.changeType;
                    replaceString = temp.replaceString;
                    time = temp.time;
                    break;
            }

            return false;
        }
    }

    public override string ToString()
    {
        return base.ToString() + ": " + parameter + " " + activationType + " " + changeType + " " + valueType + " " + value + " " + time + " " + endType;
    }

}