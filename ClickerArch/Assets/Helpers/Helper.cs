using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void VoidFunc();
public delegate void DoubleFunc(double value);
public delegate void StringFunc(string value);
public delegate void AttackFunc(double value, bool mustBeShown);

static class Helper
{
    
    public static IEnumerator Wait(float time, VoidFunc action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
