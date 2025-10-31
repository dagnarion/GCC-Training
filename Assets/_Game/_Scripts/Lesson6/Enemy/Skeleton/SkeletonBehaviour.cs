using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBehaviour : EnemyBehaviourAbstract
{
    [SerializeField] List<Transform> points;
    [SerializeField] Rigidbody2D rigi;
    [SerializeField] LayerMask player;
    [SerializeField] float CheckingArea;
    [SerializeField] float AttackAreaRadius;
    [SerializeField] Transform attackPoint;
    [SerializeField] EnemyMeleeAttack meleeAttack;
    int currentPoint;

    public override void Patrol()
    {
        rigi.velocity = transform.right * enemyData.Speed;
        if (Mathf.Abs(points[currentPoint].position.x - transform.position.x) <= 0.1f)
        {
            currentPoint++;
            if (currentPoint >= points.Count)
            {
                currentPoint = 0;
            }
            ChangeDirection(points[currentPoint].position);
        }
    }

    public override void ChangeDirection(Vector3 point)
    {
        if (transform.position.x > point.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public override void Chase(Vector3 Target)
    {
        ChangeDirection(Target);
        rigi.velocity = transform.right * enemyData.Speed;
    }

    public override bool Detect()
    {
        return Physics2D.OverlapCircle(transform.position, CheckingArea, player);
    }

    public override bool OnAttackArea()
    {
        return Physics2D.OverlapCircle(attackPoint.position, AttackAreaRadius, player);
    }

    public override void ReturnToPatrol()
    {
        ChangeDirection(points[currentPoint].position);
    }

    public override void Hit()
    {
        rigi.velocity = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.DrawSphere(points[i].position, 0.2f);
        }
        Gizmos.color = Color.white;
        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, CheckingArea);

        Gizmos.DrawWireSphere(attackPoint.position, AttackAreaRadius);
    }

    public override void Attack()
    {
        meleeAttack.Attack();
    }

    public override bool CanAttack() => meleeAttack.CanAttack();
}
