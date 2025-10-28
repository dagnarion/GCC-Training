using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHp;
    [SerializeField] PlayerHealthDataSO health;

    void Start()
    {
        Reborn();
    }

    public void Reborn()
    {
        currentHp = 1;
    }

    public void Add(int amount)
    {
        if (!isAlive()) return;
        currentHp = Mathf.Clamp(currentHp + amount, health.MinHp, health.MaxHp);
    }

    public void Detuc(int amount)
    {
        if (!isAlive()) return;
        currentHp -= amount;
    }

    public bool isAlive() => currentHp > health.MinHp;
}
