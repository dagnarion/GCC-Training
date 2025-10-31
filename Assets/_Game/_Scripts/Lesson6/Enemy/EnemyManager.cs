using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyDataSO enemyData;
    [SerializeField] StateMachine stateMachine;
    [SerializeField] HealthAbstractSystem health;
    bool isDead;
    void OnEnable()
    {
        health.Reborn(enemyData.HP, enemyData.HP);
    }
    void Start()
    {
        stateMachine.ChangeState<PatrolState>();
    }
    void Update()
    {
        if(!health.IsAlive() && !isDead)
        {
            stateMachine.ChangeState<DeadState>();
            isDead = true;
        }
    }
}
