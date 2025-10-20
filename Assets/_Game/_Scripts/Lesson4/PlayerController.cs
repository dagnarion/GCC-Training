using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigi;
    [SerializeField] float moveSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    float moveFlag;
    float horizontalVelocity;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        Handle();
        ChangeDirection();
    }

    void Handle()
    {
        moveFlag = Input.GetAxisRaw("Horizontal");
    }

    void ChangeDirection()
    {
        if (moveFlag != 0) transform.localScale = new Vector3(-moveFlag, 1, 1);
    }
    
    void FixedUpdate()
    {
        Move();
    }

    // hàm di chuyển và dừng theo gia tốc và giảm tốc
    void Move()
    {
        if (moveFlag != 0)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, moveSpeed * moveFlag, Time.fixedDeltaTime * acceleration);
        }
        else horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, deceleration * Time.fixedDeltaTime);
        rigi.velocity = new Vector2(horizontalVelocity, rigi.velocity.y);
    }

}
