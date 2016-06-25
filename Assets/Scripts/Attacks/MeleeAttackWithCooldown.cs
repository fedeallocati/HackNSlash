using System;
using UnityEngine;

public abstract class MeleeAttackWithCooldown : MeleeAttack
{
    public float attackTimer;
    public float coolDown;

    public void Update()
    {
        attackTimer = (attackTimer - Time.deltaTime).BoundLeft(0);
    }

    protected override bool CanAttack()
    {
        return Math.Abs(attackTimer) < 0.00000001;
    }

    protected override void OnAttacked()
    {
        attackTimer = coolDown;
    }
}
