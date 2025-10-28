using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string BuffType { get; }
    float Value { get; }
    float Duration { get; }
    void OnPickUp(GameObject player);
}
