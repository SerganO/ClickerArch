using System.Collections;
using System.Collections.Generic;


public enum ModificatorActivationType
{
    OneShot, Tick
}

public enum ModificatorType
{
    DPCBaseConstAdd,
    DPCBaseCoefAdd,
    DPSBaseConstAdd,
    DPSBaseCoefAdd,


    HPMaxChange,
    HPCurrentChange,
    HPCurrentCoefChange,

    AttackConst,
    AttackCoef,

    //OnAttack
    DPCConstAdd,
    DPCCoefAdd,
    DPSConstAdd,
    DPSCoefAdd,

    //OnHurt
    DamageConstReflection,
    DamageCoefReflection,
    DamageConstBlock,
    DamageCoefBlock,
}

public class Modificator
{
    static public List<ModificatorType> OnAttackGroup = new List<ModificatorType>
    {
        ModificatorType.DPCConstAdd,
        ModificatorType.DPCCoefAdd,
        ModificatorType.DPSConstAdd,
        ModificatorType.DPSCoefAdd,
    };

    static public List<ModificatorType> OnHurtGroup = new List<ModificatorType>
    {
        ModificatorType.DamageConstReflection,
        ModificatorType.DamageCoefReflection,
        ModificatorType.DamageConstBlock,
        ModificatorType.DamageCoefBlock,
    };

    public string parametersId;
    public bool isPermanent;
    public double time;
    public double value;

    public ModificatorActivationType activationType;
    public ModificatorType type;
}
