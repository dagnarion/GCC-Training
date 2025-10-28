using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Animations;
using UnityEngine;

public class ChaseEnemy : EnemyBase
{
    Vector3 oldPosition;
    [SerializeField] Transform playerPosition;
    [SerializeField] LayerMask player;
    [SerializeField] float radius;
    [SerializeField] Transform attackArea;
    bool isPlayerOnAttackArea;
    float Timer;
    [SerializeField] float delayTime;
    void Start()
    {
        SetValue(1, 10, 5);
        oldPosition = transform.position;
    }
    void Update()
    {
        CheckPlayerOnAttackArea();
        if (isPlayerOnAttackArea)
        {
            ChangeDirection(playerPosition.position);
            Move();
            Timer = delayTime;
        }
        else
        {
            Timer = Mathf.Clamp(Timer - Time.deltaTime, 0, float.MaxValue);
        }
        
        if (Timer <= 0f)
        {
            if (Mathf.Abs(transform.position.x - oldPosition.x) > 0.1f)
            {
                ChangeDirection(oldPosition);
                Move();
            }
        }
    }

    void CheckPlayerOnAttackArea()
    {
        isPlayerOnAttackArea = Physics2D.OverlapCircle(attackArea.position, radius, player);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackArea.position, radius);
    }
}
