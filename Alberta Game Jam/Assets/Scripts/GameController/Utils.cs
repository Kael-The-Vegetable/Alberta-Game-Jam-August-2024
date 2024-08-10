using System;

public static class Utils
{
    // Selects a random element of an array
    public static T SelectRandomElement<T>(this T[] values)
    {
        Random random = new();
        return values[random.Next(values.Length)];
    }
}