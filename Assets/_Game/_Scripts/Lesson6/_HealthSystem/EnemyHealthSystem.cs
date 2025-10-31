using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : HealthAbstractSystem
{
    public override void Detuct(int amount)
    {
        if (!IsAlive()) return;
        base.Detuct(amount);
        stateMachine.ChangeState<HitState>();
    }
}
