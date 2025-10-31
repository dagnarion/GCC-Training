using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : MonoBehaviour
{
    [SerializeField] protected StateMachine stateMachine;
    [SerializeField] protected float DelayTime;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackArea;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected LayerMask attackAble;
    protected float oldTime = 0;

    public bool CanAttack()
    {
        if (oldTime + DelayTime > Time.time) return false;
        return true;
    }

    public virtual void Attack()
    {
        oldTime = Time.time;
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackArea, attackAble);
        foreach (Collider2D obj in hits)
        {
            if (obj.TryGetComponent<HealthAbstractSystem>(out HealthAbstractSystem health))
            {
                health.Detuct(damage);
                Debug.Log(obj.gameObject.name + " Had Been Hit By " + transform.parent.name);
            }
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackArea);
    }
}
