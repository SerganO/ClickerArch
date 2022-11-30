using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Enum;



// CurrentHP|Immediately|NONE|Const|10|1|OneSHot|Remove

// CurrentDPC|OnAttack|NONE+Const+10+1+3+2|Time+10+1|Remove

[System.Serializable]
public class Modificator
{
    [System.Serializable]
    public enum Parameter
    {
        NONE,

        HP,
        DPC,
        DPS,
        Reflect,
        Block,

        CurrentHP,
        CurrentDPC,
        CurrentDPS,
        CurrentReflect,
        CurrentBlock,

        AdditionalXP,
        AdditionalGold,

        EnemyHP,
        HeroDPC,

        Gold,
        XP,

    }

    [System.Serializable]
    public enum ActivationType
    {
        Immediately,
        Tick,
        OnStart,
        OnAttack,
        OnHurt,
    }

    public Parameter parameter;
    public ActivationType activationType;

    public List<ChangeValue> values;

    public CheckObject checker;
    public Finalizator finalizator;

    public Modificator(string stringValue)
    {
        Configure(stringValue);
    }

    Modificator() { }

    public Modificator Clone()
    {
        List<ChangeValue> clonedValues = new List<ChangeValue>();

        values.ForEach(value => clonedValues.Add(value.Clone()));

        return new Modificator
        {
            parameter = parameter,
            activationType = activationType,
            values = clonedValues,
            checker = checker.Clone(),
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

        parameter = (Parameter)Parse(typeof(Parameter), parts[0]);
        activationType = (ActivationType)Parse(typeof(ActivationType), parts[1]);


        values = new List<ChangeValue>();

        var changeValuesParts = parts[2].Split('*');

        for(int i=0;i< changeValuesParts.Length;i++)
        {
            values.Add(new ChangeValue(changeValuesParts[i]));
        }

        checker = new CheckObject(parts[3]);
        finalizator = new Finalizator(parts[4], replacePart);
    }

    [System.Serializable]
    public class ChangeValue
    {
        public enum ValueChangeType
        {
            Const,
            Coef,
        }

        public Parameter baseParameter;
        public ValueChangeType changeType;
        public double value;

        public double onUseValueChange = 0;

        ChangeValue() { }

        public ChangeValue(string stringValue)
        {
            var parts = stringValue.Split('+');

            baseParameter = (Parameter)Parse(typeof(Parameter), parts[0]);
            changeType = (ValueChangeType)Parse(typeof(ValueChangeType), parts[1]);

            var valueNum = double.Parse(parts[2]);
            var valueDen = double.Parse(parts[3]);

            value = valueNum / valueDen;

            if(parts.Length >=6)
            {
                var changeNum = double.Parse(parts[4]);
                var changeDen = double.Parse(parts[5]);

                onUseValueChange = changeNum / changeDen;
            }

        }

        public ChangeValue Clone()
        {
            return new ChangeValue
            {
                baseParameter = baseParameter,
                changeType = changeType,
                value = value,
                onUseValueChange = onUseValueChange
            };
        }

        public void OnUseChange()
        {
            value += onUseValueChange;
        }
    }

    [System.Serializable]
    public class CheckObject
    {
        [System.Serializable]
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

    [System.Serializable]
    public class Finalizator
    {
        [System.Serializable]
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



    public void OnUseChange()
    {
        values.ForEach(value=> value.OnUseChange());
    }

    public void UpdateTime(double time)
    {
        checker.time -= time;
    }

    public bool Check()
    {
        if(NeedFinalize())
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

