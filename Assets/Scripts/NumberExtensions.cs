using System;
using UnityEngine;

public static class NumberExtensions
{
    public static int Bound(this int value, float min, float max)
    {
        var result = value;
        result = Mathf.Max(result, 1);
        result = Mathf.RoundToInt(Mathf.Min(result, max));

        return result;
    }

    public static float Bound(this float value, float min, float max)
    {
        if (min > max)
        {
            throw new ArgumentException("min must be smaller than max");
        }

        var result = value;
        result = Mathf.Max(result, 1);
        result = Mathf.Min(result, max);
        
        return result;
    }
}