using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Enum;


//public enum EffectActivationType
//{
//    OneShot, Tick
//}

//public enum EffectType
//{
//    Damage,
//    Heal,
//    Stun,
//    Color
//}

//public enum EffectValueChangeType
//{
//    Const, Coef, AddConst, AddCoef
//}

//public enum EffectEndType
//{
//    OneShot, Permanent, Time, Replacing
//}

//public class Effect
//{
//    //PARAMETER|ACTIVATION_TYPE|CHANGE_TYPE|VALUE_MAIN_PART|VALUE_SIZE_PART|TIME_MAIN_PART|TIME_SIZE_PART|END_TYPE=ATTR_KEY+ATTR_VALUE!!REPLACE

//    public EffectType parameter;
//    public EffectActivationType activationType;
//    public EffectValueChangeType changeType;
//    public double value;
//    public double time;
//    public EffectEndType endType;
//    public string replaceString;

//    public Dictionary<string, string> additionalParametrs;

//    Effect() { }

//    public Effect(string stringValue)
//    {
//        string mainPart = "";
//        string replacePart = "";

//        int index = stringValue.IndexOf('!');

//        if (index != -1)
//        {
//            mainPart = stringValue.Substring(0, index);
//            replacePart = stringValue.Substring(index + 1);
//        }
//        else
//        {
//            mainPart = stringValue;
//        }

//        var parts = mainPart.Split('|');


//        EffectType parameter = (EffectType)Parse(typeof(EffectType),parts[0]);
//        EffectActivationType activationType = (EffectActivationType)Parse(typeof(EffectActivationType), parts[1]);
//        EffectValueChangeType changeType = (EffectValueChangeType)Parse(typeof(EffectValueChangeType), parts[2]);
//        int valueMainPart = 0;
//        int valueSizePart = 1;
//        int.TryParse(parts[3], out valueMainPart);
//        int.TryParse(parts[4], out valueSizePart);
//        double value = (double)valueMainPart / valueSizePart;
//        int timeMainPart = 0;
//        int timeSizePart = 1;
//        int.TryParse(parts[5], out timeMainPart);
//        int.TryParse(parts[6], out timeSizePart);
//        double time = (double)timeMainPart / timeSizePart;
//        EffectEndType endType = (EffectEndType)Parse(typeof(EffectEndType), parts[7]);

//        Dictionary<string, string> additionalParameters = new Dictionary<string, string>();

//        var attrs = parts[8].Split('*');

//        foreach (var attr in attrs)
//        {
//            if (attr == "") continue;
//            var atrValue = attr.Split('+');

//            additionalParameters[atrValue[0]] = atrValue[1];

//        }

//        this.parameter = parameter;
//        this.activationType = activationType;
//        this.changeType = changeType;
//        this.value = value;
//        this.time = time;
//        this.endType = endType;
//        this.additionalParametrs = additionalParameters;

//        replaceString = replacePart;
//    }


//    public bool Check()
//    {
//        if (NeedReplace())
//        {
//            return Replace();
//        }
//        else
//        {
//            return false;
//        }
//    }

//    private bool NeedReplace()
//    {
//        switch (endType)
//        {
//            case EffectEndType.OneShot:
//                return true;
//            case EffectEndType.Permanent:
//                return false;
//            case EffectEndType.Time:
//                return CheckTime();
//            case EffectEndType.Replacing:
//                return CheckTime();
//        }
//        return true;
//    }

//    private bool CheckTime()
//    {
//        return time <= 0;
//    }

//    public bool Replace()
//    {
//        if (endType == EffectEndType.Replacing && CheckTime()) return true;
//        if (replaceString == "")
//        {
//            return true;
//        }
//        else
//        {

//            var temp = EffectFactory.EffectForString(replaceString);

//            parameter = temp.parameter;
//            activationType = temp.activationType;
//            endType = temp.endType;


//            switch (temp.changeType)
//            {
//                case EffectValueChangeType.AddConst:
//                    value += temp.value;
//                    break;
//                case EffectValueChangeType.AddCoef:
//                    value += value * temp.value;
//                    break;
//                default:
//                    value = temp.value;
//                    changeType = temp.changeType;
//                    replaceString = temp.replaceString;
//                    time = temp.time;
//                    additionalParametrs = temp.additionalParametrs;
//                    break;
//            }

//            return false;
//        }
//    }

//    public Effect Clone()
//    {
//        return new Effect()
//        {
//            parameter = parameter,
//            activationType = activationType,
//            changeType = changeType,
//            value = value,
//            time = time,
//            endType = endType,
//            replaceString = replaceString,

//            additionalParametrs = additionalParametrs
//        };
//    }

//    public override string ToString()
//    {
//        return base.ToString() + ": " + parameter + " " + activationType + " " + changeType + " " + " " + value + " " + time + " " + endType + " " + additionalParametrs;
//    }
//}

// Heal|Immediately|Const+10+1|Time+10+1|additional|Remove

public class Effect
{

    public enum Type
    {
        NONE,

        ConstDamage,
        Heal,
        Stun,
        Color,

        OponentDPCDamage,
    }

    public enum ActivationType
    {
        Immediately,
        Tick,
    }

    public Type type;
    public ActivationType activationType;

    public List<ChangeValue> values;

    public CheckObject checker;

    public Dictionary<string, string> additionalParametrs;

    public Finalizator finalizator;

    public Effect(string stringValue)
    {
        Configure(stringValue);
    }

    Effect() { }

    public Effect Clone()
    {
        List<ChangeValue> clonedValues = new List<ChangeValue>();

        values.ForEach(value => clonedValues.Add(value.Clone()));

        return new Effect
        {
            type = type,
            activationType = activationType,
            values = clonedValues,
            checker = checker.Clone(),
            additionalParametrs = additionalParametrs,
            finalizator = finalizator.Clone()
        };
    }

    public void Configure(string stringValue)
    {


        string mainPart = "";
        string replacePart = "";

        int index = stringValue.IndexOf('!');

        if (index != -1)
        {
            mainPart = stringValue.Substring(0, index);
            replacePart = stringValue.Substring(index + 1);
        }
        else
        {
            mainPart = stringValue;
        }

        var parts = mainPart.Split('|');

        type = (Type)Parse(typeof(Type), parts[0]);
        activationType = (ActivationType)Parse(typeof(ActivationType), parts[1]);


        values = new List<ChangeValue>();

        var changeValuesParts = parts[2].Split('*');

        for (int i = 0; i < changeValuesParts.Length; i++)
        {
            values.Add(new ChangeValue(changeValuesParts[i]));
        }

        checker = new CheckObject(parts[3]);

        Dictionary<string, string> additionalParameters = new Dictionary<string, string>();

        var attrs = parts[4].Split('*');

        foreach (var attr in attrs)
        {
            if (attr == "") continue;
            var atrValue = attr.Split('+');

            additionalParameters[atrValue[0]] = atrValue[1];

        }

        this.additionalParametrs = additionalParameters;


        finalizator = new Finalizator(parts[5], replacePart);
    }


    public class ChangeValue
    {
        public enum ValueChangeType
        {
            Const,
            Coef,
        }

        public ValueChangeType changeType;
        public double value;

        ChangeValue() { }

        public ChangeValue(string stringValue)
        {
            var parts = stringValue.Split('+');
            
            changeType = (ValueChangeType)Parse(typeof(ValueChangeType), parts[0]);

            var valueNum = double.Parse(parts[1]);
            var valueDen = double.Parse(parts[2]);

            value = valueNum / valueDen;

        }

        public ChangeValue Clone()
        {
            return new ChangeValue
            {
                changeType = changeType,
                value = value
            };
        }
    }

    public class CheckObject
    {
        public enum EndCheckType
        {
            Permanent,
            OneShot,
            Time
        }

        public EndCheckType endCheckType;
        public double time = 0;

        CheckObject() { }

        public CheckObject Clone()
        {
            return new CheckObject
            {
                endCheckType = endCheckType,
                time = time
            };
        }

        public CheckObject(string stringValue)
        {
            var parts = stringValue.Split('+');

            endCheckType = (EndCheckType)Parse(typeof(EndCheckType), parts[0]);

            switch (endCheckType)
            {
                case EndCheckType.Permanent:
                case EndCheckType.OneShot:
                    break;
                case EndCheckType.Time:
                    var timeNum = double.Parse(parts[1]);
                    var timeDen = double.Parse(parts[2]);

                    time = timeNum / timeDen;
                    break;
            }

        }
    }

    public class Finalizator
    {
        public enum EndType
        {
            Remove,
            Replace
        }

        public EndType endType;
        public string replaceString = "";

        Finalizator() { }

        public Finalizator Clone()
        {
            return new Finalizator
            {
                endType = endType,
                replaceString = replaceString
            };
        }

        public Finalizator(string stringValue, string replaceString)
        {
            endType = (EndType)Parse(typeof(EndType), stringValue);
            this.replaceString = replaceString;
        }
    }

    public void UpdateTime(double time)
    {
        checker.time -= time;
    }

    public bool Check()
    {
        if (NeedFinalize())
        {
            return Finalize();
        }
        return false;
    }


    public bool NeedFinalize()
    {
        switch (checker.endCheckType)
        {
            case CheckObject.EndCheckType.Permanent:
                return false;
            case CheckObject.EndCheckType.OneShot:
                return true;
            case CheckObject.EndCheckType.Time:
                return CheckTime();
        }

        return true;
    }

    public bool CheckTime()
    {
        return checker.time <= 0;
    }

    public bool Finalize()
    {
        switch (finalizator.endType)
        {
            case Finalizator.EndType.Remove:
                return true;
            case Finalizator.EndType.Replace:
                Configure(finalizator.replaceString);
                return false;
        }


        return true;
    }
}

