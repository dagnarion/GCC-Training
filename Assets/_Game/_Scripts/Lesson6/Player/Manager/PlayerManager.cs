using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;
    [SerializeField] StateMachine stateMachine;
    [SerializeField] HealthAbstractSystem healthSystem;
    void OnEnable()
    {
        healthSystem.Reborn(playerData.MaxHp,playerData.BaseHp);
    }
    void Start()
    {
        stateMachine.ChangeState<PlayerOnGround>();
    }
}
