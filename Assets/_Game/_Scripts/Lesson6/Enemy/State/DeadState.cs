using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : EnemyStateAbstract
{
    [SerializeField] Rigidbody2D rigi;
    [SerializeField] Collider2D coll;
    public override void Enter()
    {
        rigi.simulated = false;
        coll.enabled = false;
        enemyBehaviour.enabled = false;
        stateMachine.enabled = false;
        ani.Play("Dead");
    }

    public override void LogicsUpdate()
    {
        
    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
    
}
