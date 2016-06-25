public class Vital : ModifiedStat
{
    private int currentValue;

    public Vital()
    {
        currentValue = 0;
        ExpToLevel = 50;
        LevelModifier = 1.1f;
    }

    public enum Name
    {
        Health,
        Energy,
        Mana
    }

    public int CurrentValue
    {
        get
        {
            if (currentValue > AdjustedBaseValue)
            {
                currentValue = AdjustedBaseValue;
            }

            return currentValue;
        }
        set
        {
            currentValue = value;
            if (value > AdjustedBaseValue)
            {
                currentValue = AdjustedBaseValue;
            }
        }
    }
}
