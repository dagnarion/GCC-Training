using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IHealth
{
    [SerializeField] EnemyBase enemy;
    float currentHp;
    void OnEnable()
    {
        Reborn();
    }
    public void Add(int amount)
    {
        if (!isAlive()) return;
        currentHp = Mathf.Clamp(currentHp+amount,0,enemy.MaxHp);
    }

    public void Detuct(int amount)
    {
        if (!isAlive()) return;
        currentHp = Mathf.Clamp(currentHp-amount,0,enemy.MaxHp);
    }

    public bool isAlive() => currentHp > 0;

    public void Reborn()
    {
        currentHp = enemy.BaseHp;
    }
}
