using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void Reborn();
    void Add(int amount);
    void Detuct(int amount);
    bool isAlive();
}
