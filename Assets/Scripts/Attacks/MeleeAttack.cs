using UnityEngine;

public abstract class MeleeAttack : BaseAttack
{
    public float maxDistance;

    protected override bool IsTargetReacheable()
    {
        var distance = Vector3.Distance(target.transform.position, transform.position);
        var direction = Vector3.Dot((target.transform.position - transform.position).normalized, transform.forward);

        return distance < maxDistance && direction > 0;
    }
}
