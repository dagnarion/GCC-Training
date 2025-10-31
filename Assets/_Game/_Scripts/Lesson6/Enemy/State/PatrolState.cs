using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyStateAbstract
{
    public override void Enter()
    {
        ani.Play("Walk");
    }


    public override void LogicsUpdate()
    {
        if (enemyBehaviour.Detect()) { stateMachine.ChangeState<DetectState>(); return; }
        enemyBehaviour.Patrol();
    }

    public override void PhysicsUpdate()
    {
        
    }
    
    public override void Exit()
    {
        
    }
}
