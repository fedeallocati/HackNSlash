public class Skill : ModifiedStat
{
    public Skill()
    {
        Known = false;
        ExpToLevel = 25;
        LevelModifier = 1.1f;
    }

    public bool Known { get; set; }

    public enum Name
    {
        Melee_Offence,
        Melee_Defence,
        Ranged_Offence,
        Ranged_Defence,
        Magic_Offence,
        Magic_Defence
    }
}
