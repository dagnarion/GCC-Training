using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : EnemyStateAbstract
{
    AnimatorStateInfo aniInfo;
    public override void Enter()
    {
        ani.Play("Hit");
        enemyBehaviour.Hit();
    }


    public override void LogicsUpdate()
    {
        aniInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (aniInfo.IsName("Hit") && aniInfo.normalizedTime > 1)
        {
            stateMachine.ChangeState<PatrolState>();
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
