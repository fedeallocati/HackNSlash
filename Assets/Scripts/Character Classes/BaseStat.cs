using System;
using UnityEngine;

public class BaseStat
{
    public BaseStat()
    {
        BaseValue = 0;
        BuffValue = 0;
        LevelModifier = 1.1f;
        ExpToLevel = 100;
    }

    public int BaseValue { get; protected set; }
    public int BuffValue { get; protected set; }
    public int ExpToLevel { get; protected set; }
    public float LevelModifier { get; protected set; }

    private int CalculateExpToLevel()
    {
        return Mathf.RoundToInt(ExpToLevel * LevelModifier);
    }

    public void LevelUp()
    {
        ExpToLevel = CalculateExpToLevel();
        BaseValue++;
    }

    public virtual int AdjustedBaseValue
    {
        get
        {
            return BaseValue + BuffValue;
        }
    }
}
