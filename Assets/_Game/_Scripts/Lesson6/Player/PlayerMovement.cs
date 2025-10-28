using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerMovementDataSO playerData;
    [SerializeField] Rigidbody2D rigi;
    [SerializeField] BoxCollider2D col;
    [SerializeField] LayerMask ground;
    [SerializeField] Vector3 size;
    List<ActiveBuff> buffs = new List<ActiveBuff>();
    Vector2 groundCheckArea;
    bool isOnGround;

    float moveFlag;
    float targetVelocity;
    float speedBuffValue;
    float jumpBuffValue;


    void Update()
    {
        Handle();
        GroundCheck();
        UpdateBuff();
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) Jump();
    }

    void Handle()
    {
        moveFlag = Input.GetAxisRaw("Horizontal");
    }
    void Move()
    {
        if (moveFlag != 0)
        {
            targetVelocity = Mathf.Lerp(targetVelocity, (playerData.MaxSpeed + speedBuffValue) * moveFlag, playerData.Acceleration * Time.deltaTime);
        }
        else targetVelocity = Mathf.Lerp(targetVelocity, 0, playerData.Deceleration * Time.deltaTime);
        rigi.velocity = new Vector2(targetVelocity, rigi.velocity.y);
    }
    void Jump()
    {
        rigi.velocity = new Vector2(rigi.velocity.x,playerData.JumpForce + jumpBuffValue);
    }
    void GroundCheck()
    {
        groundCheckArea = new Vector2(col.bounds.center.x, col.bounds.min.y);
        isOnGround = Physics2D.OverlapBox(groundCheckArea, size, 0, ground);
    }

    public void UpdateBuff()
    {
        speedBuffValue = 0;
        jumpBuffValue = 0;
        rigi.gravityScale = playerData.originGravity;
        if (buffs.Count == 0) return;
        for (int i = 0; i < buffs.Count; i++)
        {
            var tmp = buffs[i];
            tmp.DecreaseTime();
            switch (tmp.type)
            {
                case "Speed":
                    speedBuffValue = tmp.value;
                    break;
                case "Jump":
                    jumpBuffValue = tmp.value;
                    break;
                case "Gravity":
                    rigi.gravityScale = tmp.value;
                    break;
            }
            if (tmp.timeLeft <= 0f) buffs.RemoveAt(i);
        }
    }

    public void AddBuff(IItem buff)
    {
        buffs.Add(new ActiveBuff(buff.BuffType, buff.Value, buff.Duration));
    }


    //Draw Check Area
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        groundCheckArea = new Vector2(col.bounds.center.x, col.bounds.min.y);
        Gizmos.DrawWireCube(groundCheckArea, size);
    }
}
public class ActiveBuff
{
    public string type { get; private set; }
    public float value { get; private set; }
    public float timeLeft { get; private set; }
    public ActiveBuff(string _type, float _value, float _timeLeft)
    {
        type = _type;
        value = _value;
        timeLeft = _timeLeft;
    }
    public void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
    }
}