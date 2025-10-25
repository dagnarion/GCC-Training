using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : PlayerAbstract
{
    [SerializeField] float force;
    IAttackable enemy;

    void OnEnable()
    {
        playerReference.Controller.onAttackPressed += Attack;
    }

    void OnDisable()
    {
        playerReference.Controller.onAttackPressed -= Attack;
    }

    void Attack()
    {
      // tat collider
    }

    // kiểm tra xem object mà vùng tấn công cast được có phải là object cho phép tấn công không
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        collision.TryGetComponent<IAttackable>(out enemy);
        if (enemy != null)
        {
            enemy.TakeForce(force, new Vector2(-transform.localScale.x, 0.5f));
        }
        enemy = null;
    }

}
