using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigi;
    protected float speed;
    protected float health;
    protected float damage;
    protected void SetValue(float _speed, float _health, float _damage)
    {
        speed = _speed;
        health = _health;
        damage = _damage;
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
