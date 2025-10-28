using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigi;
    protected float speed;
    protected float maxHp;
    protected float damage;
    protected float baseHp;
    public float MaxHp => maxHp;
    public float BaseHp => baseHp;
    protected void SetValue(float _speed, float _maxHp,float _baseHp, float _damage)
    {
        speed = _speed;
        maxHp = _maxHp;
        damage = _damage;
        baseHp = _baseHp;
    }
    protected virtual void ChangeDirection(Vector3 point)
    {
        if (transform.position.x > point.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    protected virtual void Move()
    {
        rigi.velocity = transform.right * speed;
    }
}
