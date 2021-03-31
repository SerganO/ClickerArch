using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        var parts = mainPart.Split('=');


        ModificatorParameter parameter = ParametrForString(parts[0]);
        ModificatorValueType valueType = ValueTypeForString(parts[1]);
        ModificatorActivationType activationType = ActivationTypeForString(parts[2]);
        ModificatorValueChangeType changeType = ChangeTypeForString(parts[3]);
        int valueMainPart = 0;
        int valueSizePart = 1;
        int.TryParse(parts[4], out valueMainPart);
        int.TryParse(parts[5], out valueSizePart);
        double value = (double)valueMainPart / valueSizePart;
        int timeMainPart = 0;
        int timeSizePart = 1;
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