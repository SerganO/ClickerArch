public enum ModificatorValueType
{
    Base,
    Current
}

public enum ModificatorParameter
{
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

    public Modificator Clone()
    {
        return new Modificator()
        {
            parameter = parameter,
            activationType = activationType,
            changeType = changeType,
            valueType = valueType,
            value = value,
            time = time,
            endType = endType,
            replaceString = replaceString,

        };
    }

    public override string ToString()
    {
        return base.ToString() + ": " + parameter + " " + activationType + " " + changeType + " " + valueType + " " + value + " " + time + " " + endType;
    }

}