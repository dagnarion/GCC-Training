using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectState : EnemyStateAbstract
{
    AnimatorStateInfo aniInfo;
    [SerializeField] Rigidbody2D rigi;
    public override void Enter()
    {
        rigi.velocity = Vector2.zero;
        ani.Play("React");
    }

    public override void LogicsUpdate()
    {
        enemyBehaviour.ChangeDirection(player.position);
        aniInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (aniInfo.IsName("React") && aniInfo.normalizedTime > 1)
        {
            if (!enemyBehaviour.Detect())
            {
                enemyBehaviour.ReturnToPatrol();
                stateMachine.ChangeState<PatrolState>();
                return;
            }
            if(enemyBehaviour.OnAttackArea())
            {
                stateMachine.ChangeState<AttackState>();
                return;
            }
            stateMachine.ChangeState<ChaseState>();
            return;
            
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
}
