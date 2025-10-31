using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AttackState : EnemyStateAbstract
{
    AnimatorStateInfo aniInfo;
    bool hasHit;
    public override void Enter()
    {
        if (!enemyBehaviour.CanAttack()) { stateMachine.ChangeState<DetectState>(); return; }
        ani.Play("Attack");
        hasHit = false;
    }

    public override void LogicsUpdate()
    {
        aniInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (aniInfo.IsName("Attack"))
        {
            float timer = aniInfo.normalizedTime;
            if (timer >= 0.6f && timer <= 0.8f)
            {
                if (!hasHit && enemyBehaviour.OnAttackArea())
                {
                    enemyBehaviour.Attack();
                    hasHit = true;
                }
            }
            if (timer > 1)
            {
                stateMachine.ChangeState<DetectState>();
                return;
            }
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {
        hasHit = false;
    }
}
