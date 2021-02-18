using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Helper
{
    public delegate void VoidFunc();
    public static IEnumerator Wait(float time, VoidFunc action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
