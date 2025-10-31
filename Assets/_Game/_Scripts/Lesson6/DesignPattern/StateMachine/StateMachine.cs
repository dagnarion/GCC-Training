using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    StateAbstract currentState;
    Dictionary<Type, StateAbstract> states;

    void Awake()
    {
        states = new Dictionary<Type, StateAbstract>();
        foreach(StateAbstract stateInChild in this.GetComponentsInChildren<StateAbstract>())
        {
            if(!states.ContainsKey(stateInChild.GetType()))
            {
                states.Add(stateInChild.GetType(), stateInChild);
            }
        }
    }

    void Update()
    {
        currentState?.LogicsUpdate();
    }

    void FixedUpdate()
    {
        currentState?.PhysicsUpdate();
    }

    public void ChangeState<T>() where T:StateAbstract
    {
        if (!states.ContainsKey(typeof(T))) { Debug.Log(gameObject.name + " Does Not Contain " + typeof(T).ToString());  return; }
        ChangeState(states[typeof(T)]);
    }
    public void ChangeState(StateAbstract nextState)
    {
        if (currentState != null && currentState.GetType() == nextState.GetType()) return;
        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }
}
