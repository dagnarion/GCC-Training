using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PlayerDataSO/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Health")]
    public int MaxHp;
    public int BaseHp;

    [Header("Ground")]
    public float MaxGroundMovingSpeed;
    public float GroundAcceleration;
    public float GroundDeceleration;
    
    [Header("OnAir")]
    public float MaxAirMovingSpeed;
    public float MaxFallingSpeed;
    public float AirAcceleration;
    public float AirDeceleration;

    [Header("Jump")]
    public float JumpForce;
}
