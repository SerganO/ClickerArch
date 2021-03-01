using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void VoidFunc();

static class Helper
{
    
    public static IEnumerator Wait(float time, VoidFunc action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
