using System.Collections.Generic;
using UnityEngine;

public class ModifiedStat : BaseStat
{
    private List<ModifyingAttribute> mods;
    private int modValue;

    public ModifiedStat()
    {
        mods = new List<ModifyingAttribute>();
        modValue = 0;
    }

    public struct ModifyingAttribute
    {
        public Attribute attribute;
        public float ratio;

        public ModifyingAttribute(Attribute att, float rat)
        {
            attribute = att;
            ratio = rat;
        }
    }

    public override int AdjustedBaseValue
    {
        get { return base.AdjustedBaseValue + modValue; }
    }

    public void AddModifier(ModifyingAttribute mod)
    {
        mods.Add(mod);
    }

    public void Update()
    {
        CalculateModValue();
    }

    private void CalculateModValue()
    {
        modValue = 0;
        foreach (var mod in mods)
        {
            modValue += Mathf.RoundToInt(mod.attribute.AdjustedBaseValue * mod.ratio);
        }
    }
}