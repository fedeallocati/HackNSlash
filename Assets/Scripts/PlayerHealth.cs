using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;

    public float healthBarLength;

    // Use this for initialization
    public void Start()
    {
        healthBarLength = Screen.width / 2.0f;
    }

    // Update is called once per frame
    public void Update()
    {
        AdjustCurrentHealth(0);
        EnforceConstraints();
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
    }

    public void AdjustCurrentHealth(int adjustement)
    {
        currentHealth = (currentHealth + adjustement).Bound(1, maxHealth);

        healthBarLength = Screen.width / 2.0f * (currentHealth / (float)maxHealth);
    }

    private void EnforceConstraints()
    {
        currentHealth = currentHealth.Bound(1, maxHealth);
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
    }
}
