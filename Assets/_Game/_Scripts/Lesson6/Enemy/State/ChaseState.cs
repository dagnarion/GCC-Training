using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyStateAbstract
{
    public override void Enter()
    {
        ani.Play("Walk");
    }

    public override void LogicsUpdate()
    {
        enemyBehaviour.Chase(player.position);
        if (!enemyBehaviour.Detect()) { stateMachine.ChangeState<DetectState>(); return; }
        if(enemyBehaviour.OnAttackArea()) { stateMachine.ChangeState<AttackState>(); return; }
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
}
