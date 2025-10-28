using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IHealth
{
    int currentHp;
    [SerializeField] PlayerHealthDataSO health;
    void OnEnable()
    {
        Reborn();
    }
    public virtual void Reborn()
    {
        currentHp = 1;
    }

    public virtual void Add(int amount)
    {
        if (!isAlive()) return;
        currentHp = Mathf.Clamp(currentHp + amount, health.MinHp, health.MaxHp);
    }

    public virtual void Detuct(int amount)
    {
        if (!isAlive()) return;
        currentHp -= amount;
    }

    public virtual bool isAlive() => currentHp > health.MinHp;
}