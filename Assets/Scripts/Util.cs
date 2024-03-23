using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static T Random<T>(this IList<T> enumerable)
    {
        return enumerable[UnityEngine.Random.Range(0, enumerable.Count)];
    }
}
