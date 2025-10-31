using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStateAbstract : StateAbstract
{
    [SerializeField] protected EnemyDataSO enemyData;
    [SerializeField] protected StateMachine stateMachine;
    [SerializeField] protected EnemyBehaviourAbstract enemyBehaviour;
    [SerializeField] protected Animator ani;
    protected Transform player;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
