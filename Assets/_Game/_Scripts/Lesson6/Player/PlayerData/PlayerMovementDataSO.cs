using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PlayerSO/PlayerMovementData")]
public class PlayerMovementDataSO : ScriptableObject
{
    public float MaxSpeed;
    public float Acceleration;
    public float Deceleration;
    public float JumpForce;
    public float originGravity;
}
