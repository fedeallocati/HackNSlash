using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public GameObject target;

    protected virtual bool CanAttack()
    {
        return true;
    }

    protected virtual bool IsTargetReacheable()
    {
        return true;
    }

    protected abstract void ExecuteAttack();

    protected virtual void OnAttacked()
    {

    }

    protected void TryToAttack()
    {
        if (CanAttack())
        {
            Attack();
        }
    }

    protected void Attack()
    {
        if (IsTargetReacheable())
        {
            ExecuteAttack();
        }

        OnAttacked();
    }
}
