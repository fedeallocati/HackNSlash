using UnityEngine;
using Enum = System.Enum;

public class CharacterGenerator : MonoBehaviour
{
    private PlayerCharacter toon;
    private const int StartingPoints = 350;
    private const int MinAttributeValue = 10;
    private const int StartingValue = 50;
    private int pointsLeft;

    private const int Offset = 5;
    private const int LineHeight = 23;
    private const int ColumnWidth = 7*Offset + StatLabelWidth + StatValueLabelWidth + 2*ButtonWidth;

    private const int StatLabelWidth = 100;
    private const int StatValueLabelWidth = 30;
    private const int ButtonWidth = 20;
    private const int ButtonHeight = 20;


    // Use this for initialization
    public void Start()
    {
        toon = new PlayerCharacter();
        toon.Awake();

        pointsLeft = StartingPoints;

        ForEachInEnumDo((Attribute.Name a) =>
        {
            toon.GetPrimaryAttribute(a).BaseValue = StartingValue;
            pointsLeft -= StartingValue - MinAttributeValue;
        });

        toon.StatUpdate();
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
        GUI.Label(new Rect(Offset, 10, 50, 25), "Name:");
        toon.Name = GUI.TextField(new Rect(Offset + 50, 10, 100, 25), toon.Name);
    }

    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(ColumnWidth + Offset, 10, 100, 25), "Points Left: " + pointsLeft);
    }

    private void DisplayAttributes()
    {
        ForEachInEnumDo((Attribute.Name a) =>
        {
            var i = (int) a;
            var attribute = toon.GetPrimaryAttribute(i);
            var rowPosition = Offset;
            GUI.Label(new Rect(rowPosition, 40 + (i*LineHeight), StatLabelWidth, LineHeight), a.ToString());
            rowPosition += StatLabelWidth + Offset;
            GUI.Label(new Rect(rowPosition, 40 + (i* LineHeight), StatValueLabelWidth, LineHeight), attribute.AdjustedBaseValue.ToString());
            rowPosition += StatValueLabelWidth + Offset;
            if (GUI.Button(new Rect(rowPosition, 40 + (i* ButtonHeight), ButtonWidth, ButtonHeight), "-"))
            {
                if (attribute.BaseValue > MinAttributeValue)
                {
                    attribute.BaseValue--;
                    pointsLeft++;
                    toon.StatUpdate();
                }
            }

            rowPosition += ButtonWidth + Offset;

            if (GUI.Button(new Rect(rowPosition, 40 + (i* ButtonHeight), ButtonWidth, ButtonHeight), "+"))
            {
                if (pointsLeft > 0)
                {
                    attribute.BaseValue++;
                    pointsLeft--;
                    toon.StatUpdate();
                }
            }
        });
    }

    private void DisplayVitals()
    {
        var offsetRows = Enum.GetValues(typeof(Attribute.Name)).Length;

        ForEachInEnumDo((Vital.Name a) =>
        {
            var i = (int) a;
            var rowPosition = Offset;
            GUI.Label(new Rect(rowPosition, 40 + ((i + offsetRows)*LineHeight), StatLabelWidth, LineHeight), a.ToString());
            rowPosition += StatLabelWidth + Offset;
            GUI.Label(new Rect(rowPosition, 40 + ((i + offsetRows)* LineHeight), StatValueLabelWidth, LineHeight), toon.GetVital(i).AdjustedBaseValue.ToString());
        });
    }

    private void DisplaySkills()
    {
        ForEachInEnumDo((Skill.Name a) =>
        {
            var i = (int) a;
            var rowPosition = ColumnWidth + Offset;
            GUI.Label(new Rect(rowPosition, 40 + (i* LineHeight), StatLabelWidth, LineHeight), a.ToString());
            rowPosition += StatLabelWidth + Offset;
            GUI.Label(new Rect(rowPosition, 40 + (i* LineHeight), StatValueLabelWidth, LineHeight), toon.GetSkill(i).AdjustedBaseValue.ToString());
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
