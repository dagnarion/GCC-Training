using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerStateAbstract
{
    AnimatorStateInfo aniInfo;
    Coroutine stateCoroutine;
    bool isAttacking = true;
    public override void Enter()
    {
        ani.Play("Attack");
    }

    public override void Exit()
    {
        isAttacking = true;
    }

    public override void LogicsUpdate()
    {
        aniInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (aniInfo.IsName("Attack") && aniInfo.normalizedTime > 1 && isAttacking)
        {
            if (stateCoroutine != null) StopCoroutine(stateCoroutine);
            stateCoroutine = StartCoroutine(ChangeState());
            isAttacking = false;
            return;
        }
    }

    public override void PhysicsUpdate()
    {

    }
    
    IEnumerator ChangeState()
    {
        yield return null;
        if (movement.IsOnGround) { stateMachine.ChangeState<PlayerOnGround>();}
        else stateMachine.ChangeState<PlayerOnAir>();
    }
}
