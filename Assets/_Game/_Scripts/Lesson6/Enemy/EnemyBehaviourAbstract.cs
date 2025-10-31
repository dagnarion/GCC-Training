using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviourAbstract : MonoBehaviour
{
    [SerializeField] protected EnemyDataSO enemyData;
    public abstract void ChangeDirection(Vector3 point);
    public abstract void Hit();
    public abstract void Patrol();
    public abstract bool Detect();
    public abstract bool OnAttackArea();
    public abstract bool CanAttack();
    public abstract void Attack();
    public abstract void Chase(Vector3 Target);
    public abstract void ReturnToPatrol();
}
// em định code state machine chạy chung cho tất cả enemy nhưng mà em thấy có vẻ hơi khó kiểm soát.... :<
