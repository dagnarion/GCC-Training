using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : PlayerStateAbstract
{
    [SerializeField] Collider2D coll;
    [SerializeField] Rigidbody2D rigi;
    public override void Enter()
    {
        ani.Play("Dead");
        coll.enabled = false;
        rigi.simulated = false;
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
