using UnityEngine;

public class EnemyAttack : MeleeAttackWithCooldown
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

        TryToAttack();
    }

    protected override void ExecuteAttack()
    {
        target.GetComponent<PlayerHealth>().AdjustCurrentHealth(-10);
    }
}
