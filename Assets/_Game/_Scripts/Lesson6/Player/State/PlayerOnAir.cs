using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnAir : PlayerStateAbstract
{
    public override void Enter()
    {
        ani.Play("Falling");
    }

    public override void LogicsUpdate()
    {
        if (movement.IsOnGround) { stateMachine.ChangeState<PlayerOnGround>(); return; }
        movement.Move(playerData.MaxAirMovingSpeed,playerData.AirAcceleration,playerData.AirDeceleration);
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
}
