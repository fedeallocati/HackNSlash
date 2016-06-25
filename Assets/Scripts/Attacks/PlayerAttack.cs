using UnityEngine;

public class PlayerAttack : MeleeAttackWithCooldown
{
    // Use this for initialization
    public void Start()
    {
        attackTimer = 0;
        coolDown = 2.0f;
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();

        if (Input.GetKeyUp(KeyCode.F))
        {
            TryToAttack();
        }
    }

    protected override void ExecuteAttack()
    {
        target.GetComponent<EnemyHealth>().AdjustCurrentHealth(-10);
    }
}
