using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void TakeForce(float force,Vector2 Direction);
}
