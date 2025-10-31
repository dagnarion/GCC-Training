using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MeleeAttack
{
    void OnEnable()
    {
        InputManager.Attack += Attack;
    }
    void OnDisable()
    {
        InputManager.Attack -= Attack;
    }
    public override void Attack()
    {
        if (!CanAttack()) return;
        base.Attack();
        stateMachine.ChangeState<PlayerAttack>();
    }
    public void IncreaseDamage(int value)
    {
        damage += value;
    }
}
