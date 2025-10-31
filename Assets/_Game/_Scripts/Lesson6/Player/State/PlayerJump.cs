using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerStateAbstract
{
    public override void Enter()
    {
        movement.Jump();
        ani.Play("Jump");
    }

    public override void LogicsUpdate()
    {
        if (movement.IsOnGround)
        {
            stateMachine.ChangeState<PlayerOnGround>();
            return;
        }
        if (inputManager.IsJumpRelease || movement.IsJumpDone() || movement.IsOnWall || movement.IsBumpHead) { stateMachine.ChangeState<PlayerOnAir>(); return; }
        
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
}
