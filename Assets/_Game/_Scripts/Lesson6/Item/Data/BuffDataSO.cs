using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "BuffDataSO/BuffData")]
public class BuffDataSO : ScriptableObject
{
    public string BuffName;
    public TypeOfBuff type;
    public float Value;
    public float LifeTime;
}
public enum TypeOfBuff
{
    Speed,Damage,Jump,Heal
}