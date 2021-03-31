using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory
{

    //PARAMETER===ACTIVATION_TYPE===CHANGE_TYPE===VALUE_MAIN_PART===VALUE_SIZE_PART===TIME_MAIN_PART===TIME_SIZE_PART===END_TYPE=ATTR_KEY*ATTR_VALUE||REPLACE

    public static Effect EffectForString(string rawString)
    {


        if (rawString == "")
        {
            return null;
        }


        string mainPart = "";
        string replacePart = "";

        int index = rawString.IndexOf('|');

        if (index != -1)
        {
            mainPart = rawString.Substring(0, index);
            replacePart = rawString.Substring(index + 1);
        }
        else
        {
            mainPart = rawString;
        }

        var parts = mainPart.Split('=');


        EffectType parameter = ParametrForString(parts[0]);
        EffectActivationType activationType = ActivationTypeForString(parts[1]);
        EffectValueChangeType changeType = ChangeTypeForString(parts[2]);
        int valueMainPart = 0;
        int valueSizePart = 1;
        int.TryParse(parts[3], out valueMainPart);
        int.TryParse(parts[4], out valueSizePart);
        double value = (double)valueMainPart / valueSizePart;
        int timeMainPart = 0;
        int timeSizePart = 1;
        int.TryParse(parts[5], out timeMainPart);
        int.TryParse(parts[6], out timeSizePart);
        double time = (double)timeMainPart / timeSizePart;
        EffectEndType endType = EndTypeForString(parts[7]);

        Dictionary<string, string> additionalParameters = new Dictionary<string, string>();

        var attrs = parts[8].Split('-');
        
        foreach(var attr in attrs)
        {
            if (attr == "") continue;
            var atrValue = attr.Split('*');

            additionalParameters[atrValue[0]] = atrValue[1];

        }

        Effect result = new Effect
        {
            parameter = parameter,
            activationType = activationType,
            changeType = changeType,
            value = value,
            time = time,
            endType = endType,
            additionalParametrs = additionalParameters
        };

        result.replaceString = replacePart;

        return result;
    }

    static EffectType ParametrForString(string str)
    {
        return ((EffectType)System.Enum.Parse(typeof(EffectType), str));
    }

    static EffectActivationType ActivationTypeForString(string str)
    {
        return ((EffectActivationType)System.Enum.Parse(typeof(EffectActivationType), str));
    }

    static EffectValueChangeType ChangeTypeForString(string str)
    {
        return ((EffectValueChangeType)System.Enum.Parse(typeof(EffectValueChangeType), str));
    }

    static EffectEndType EndTypeForString(string str)
    {
        return ((EffectEndType)System.Enum.Parse(typeof(EffectEndType), str));
    }

}