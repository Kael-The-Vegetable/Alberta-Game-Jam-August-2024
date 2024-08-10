﻿using System;

public static class Utils
{
    // Selects a random element of an array
    public static T SelectRandomElement<T>(this T[] values) => values[Singleton.Global.Random.Next(values.Length)];
}