using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void VoidFunc();
public delegate void DoubleFunc(double value);
public delegate void BoolFunc(bool value);
public delegate void StringFunc(string value);
public delegate void AttackFunc(double value, bool mustBeShown);

public delegate void RecipeList(List<Recipe> list);

public static class Helper
{
    
    public static IEnumerator Wait(float time, VoidFunc action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public static string ColorText(string color, string text)
    {
        return "<color=" + color + ">" + text + "</color>";
    }

    public static void ClearTransform(Transform transform)
    {
        foreach(Transform tr in transform)
        {
            Object.Destroy(tr.gameObject);
        }
    }
}
