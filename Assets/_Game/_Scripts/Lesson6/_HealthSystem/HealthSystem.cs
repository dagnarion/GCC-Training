using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthAbstractSystem : MonoBehaviour
{
    [SerializeField] protected StateMachine stateMachine;
    int currentHp;
    int MaxHp;
    public virtual void Add(int amount)
    {
        if (!IsAlive()) return;
        currentHp = Mathf.Clamp(currentHp + amount, 0, MaxHp);
    }
    public virtual void Detuct(int amount)
    {
        if (!IsAlive()) return;
        currentHp = Mathf.Clamp(currentHp - amount, 0, MaxHp);
    }
    public virtual void Reborn(int _MaxHp,int _BaseHp)
    {
        MaxHp = _MaxHp;
        currentHp = _BaseHp;
    }
    public virtual bool IsAlive() => currentHp > 0;
}
