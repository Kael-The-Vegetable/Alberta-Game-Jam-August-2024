using System;
using UnityEngine;

public static class Utils
{
    // Selects a random element of an array
    public static T SelectRandomElement<T>(this T[] values)
    {
        if (values.Length > 0)
        { return values[Singleton.Global.Random.Next(values.Length)]; }
        else
        { return default; }
    }

    public static bool ValueBetween(this int value, int min, int max)
    {
        return value >= min && value <= max;
    }
}