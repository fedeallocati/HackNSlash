using System;
using UnityEngine;

public static class NumberExtensions
{
    public static int Bound(this int value, int min, int max)
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

    public static int BoundLeft(this int value, int min)
    {
        return value < min ? min : value;
    }

    public static float BoundLeft(this float value, float min)
    {
        return value < min ? min : value;
    }

    public static int BoundRight(this int value, int max)
    {
        return value > max ? max : value;
    }

    public static float BoundRight(this float value, float max)
    {
        return value > max ? max : value;
    }
}