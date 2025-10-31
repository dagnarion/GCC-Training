using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateAbstract : StateAbstract
{
    [SerializeField] protected PlayerDataSO playerData;
    [SerializeField] protected Animator ani;
    protected PlayerMovement movement;
    protected StateMachine stateMachine;
    protected virtual void Awake()
    {
        movement = this.transform.parent.parent.GetComponent<PlayerMovement>();
        stateMachine = this.GetComponentInParent<StateMachine>();

    }

    // =)) em thấy việc kéo từng ref cho state khá lười nên làm tạm 
    // hẹ hẹ hẹ
}
