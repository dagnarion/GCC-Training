using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateAbstract : MonoBehaviour
{
    public abstract void Enter();
    public abstract void LogicsUpdate();
    public abstract void PhysicsUpdate();
    public abstract void Exit();
}
