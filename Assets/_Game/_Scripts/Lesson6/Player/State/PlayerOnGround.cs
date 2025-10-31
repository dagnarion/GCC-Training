using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : PlayerStateAbstract
{
    [SerializeField] float CoyoteTime;
    float Timer;
    public override void Enter()
    {
        Timer = CoyoteTime;
        ani.Play(CONSTANT.PlayerGrounded);
    }

    public override void LogicsUpdate()
    {
        if (movement.IsOnGround)
        {
            Timer = CoyoteTime;
        }
        else Timer -= Time.deltaTime;
        if (Timer <= 0f) { stateMachine.ChangeState<PlayerOnAir>(); return; }
        if (Timer > 0f && InputManager.Instance.IsJumpPress) { stateMachine.ChangeState<PlayerJump>(); return; }
        movement.Move(playerData.MaxGroundMovingSpeed, playerData.GroundAcceleration,playerData.GroundDeceleration);
        ani.SetFloat(CONSTANT.PlayerMoving, movement.GroundMoveProgress);
    }

    public override void PhysicsUpdate()
    {
       
    }

    public override void Exit()
    {

    }
}
