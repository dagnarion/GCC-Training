using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float force;
    IAttackable enemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enemy != null)
        {
            enemy.TakeForce(force, new Vector2(-transform.localScale.x, Vector2.up.y));
        }
    }

    // kiểm tra xem object mà vùng tấn công cast được có phải là object cho phép tấn công không
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        enemy = collision.GetComponent<IAttackable>();
    }

    // xóa ref đến object đang bị tác động
    void OnTriggerExit2D(Collider2D collision)
    {
        if(enemy!=null) enemy = null;
    }
}
