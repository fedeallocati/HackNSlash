using UnityEngine;
using Enum = System.Enum;

public class CharacterGenerator : MonoBehaviour
{
    private PlayerCharacter toon;
    private const int StartingPoints = 350;
    private const int MinStartingAttributeValue = 10;
    private int pointsLeft;
    
    // Use this for initialization
    public void Start()
    {
        toon = new PlayerCharacter();
        toon.Awake();

        pointsLeft = StartingPoints;

        ForEachInEnumDo((Attribute.Name a) =>
        {
            toon.GetPrimaryAttribute(a).BaseValue = MinStartingAttributeValue;
        });
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void OnGUI()
    {
        DisplayName();
        DisplayPointsLeft();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();
    }

    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name:");
        toon.Name = GUI.TextArea(new Rect(65, 10, 100, 25), toon.Name);
    }

    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft);
    }

    private void DisplayAttributes()
    {
        ForEachInEnumDo((Attribute.Name a) =>
        {
            var i = (int) a;
            GUI.Label(new Rect(10, 40 + (i*25), 100, 25), a.ToString());
            GUI.Label(new Rect(115, 40 + (i*25), 30, 25),
                toon.GetPrimaryAttribute(i).AdjustedBaseValue.ToString());
            GUI.Button(new Rect(150, 40 + (i*25), 25, 25), "-");
            GUI.Button(new Rect(180, 40 + (i * 25), 25, 25), "+");
        });
    }

    private void DisplayVitals()
    {
        var offsetRows = Enum.GetValues(typeof(Attribute.Name)).Length;

        ForEachInEnumDo((Vital.Name a) =>
        {
            var i = (int) a;
            GUI.Label(new Rect(10, 40 + ((i + offsetRows)*25), 100, 25), a.ToString());
            GUI.Label(new Rect(115, 40 + ((i + offsetRows)*25), 30, 25), toon.GetVital(i).AdjustedBaseValue.ToString());
        });
    }

    private void DisplaySkills()
    {
        ForEachInEnumDo((Skill.Name a) =>
        {
            var i = (int) a;
            GUI.Label(new Rect(250, 40 + (i*25), 100, 25), a.ToString());
            GUI.Label(new Rect(355, 40 + (i*25), 30, 25), toon.GetSkill(i).AdjustedBaseValue.ToString());
        });
    }

    private void ForEachInEnumDo<T>(System.Action<T> action) where T : System.IConvertible
    {
        var lengh = Enum.GetValues(typeof(T)).Length;

        for (var i = 0; i < lengh; i++)
        {
            action((T)(object)i);
        }
    }
}
