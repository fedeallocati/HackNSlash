using Enum = System.Enum;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    private Attribute[] primaryAttributes;
    private Vital[] vitals;
    private Skill[] skills;

    public void Awake()
    {
        Name = string.Empty;
        Level = 0;
        FreeExp = 0;

        primaryAttributes = new Attribute[Enum.GetValues(typeof(Attribute.Name)).Length];
        vitals = new Vital[Enum.GetValues(typeof(Vital.Name)).Length];
        skills = new Skill[Enum.GetValues(typeof(Skill.Name)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
        SetupSkills();
    }

    public string Name { get; set; }
    public uint Level { get; set; }
    public uint FreeExp { get; set; }

    public void AddExp(uint exp)
    {
        FreeExp += exp;
        CalculateLevel();
    }

    public void CalculateLevel()
    {
        
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return primaryAttributes[index];
    }

    public Attribute GetPrimaryAttribute(Attribute.Name attributeName)
    {
        return primaryAttributes[(int)attributeName];
    }

    public Vital GetVital(int index)
    {
        return vitals[index];
    }

    public Vital GetVital(Vital.Name vitalName)
    {
        return vitals[(int)vitalName];
    }

    public Skill GetSkill(int index)
    {
        return skills[index];
    }

    public Skill GetSkill(Skill.Name skillName)
    {
        return skills[(int)skillName];
    }

    public void StatUpdate()
    {
        foreach (var vital in vitals)
        {
            vital.Update();
        }

        foreach (var skill in skills)
        {
            skill.Update();
        }
    }

    private void SetupPrimaryAttributes()
    {
        for (int cnt = 0; cnt < primaryAttributes.Length; cnt++)
        {
            primaryAttributes[cnt] = new Attribute();
        }
    }

    private void SetupVitals()
    {
        for (int cnt = 0; cnt < vitals.Length; cnt++)
        {
            vitals[cnt] = new Vital();
        }
    }

    private void SetupSkills()
    {
        for (int cnt = 0; cnt < skills.Length; cnt++)
        {
            skills[cnt] = new Skill();
        }
    }

    private void SetupVitalModifiers()
    {
        GetVital(Vital.Name.Health).AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Constitution), .5f));

        GetVital(Vital.Name.Energy).AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Constitution), 1f));

        GetVital(Vital.Name.Mana).AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Willpower), 1f));
    }

    private void SetupSkillModifiers()
    {
        var meleeOffence = GetSkill(Skill.Name.Melee_Offence);

        meleeOffence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Might), .33f));
        meleeOffence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Nimbleness), .33f));

        var meleeDefence = GetSkill(Skill.Name.Melee_Defence);

        meleeDefence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Speed), .33f));
        meleeDefence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Constitution), .33f));

        var rangedOffence = GetSkill(Skill.Name.Ranged_Offence);

        rangedOffence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Concentration), .33f));
        rangedOffence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Speed), .33f));

        var rangedDefence = GetSkill(Skill.Name.Ranged_Defence);

        rangedDefence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Speed), .33f));
        rangedDefence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Nimbleness), .33f));

        var magicOffence = GetSkill(Skill.Name.Magic_Offence);

        magicOffence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Concentration), .33f));
        magicOffence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Willpower), .33f));

        var magicDefence = GetSkill(Skill.Name.Magic_Defence);

        magicDefence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Constitution), .33f));
        magicDefence.AddModifier(new ModifiedStat.ModifyingAttribute
            (GetPrimaryAttribute(Attribute.Name.Willpower), .33f));
    }
}
