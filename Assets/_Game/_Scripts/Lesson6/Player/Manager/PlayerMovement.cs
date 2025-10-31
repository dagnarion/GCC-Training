using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;

    [Header("CheckingArea")]
    [SerializeField] Collider2D coll;
    [SerializeField] Transform WallCheckPoint;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask wall;
    [SerializeField] Vector2 GroundCheckAreaSize;
    [SerializeField] Vector2 WallCheckAreaSize;
    [SerializeField] Vector2 HeadCheckAreaSize;
    Vector2 GroundArea, HeadArea;
    public bool IsOnGround { get; private set; }
    public bool IsOnWall { get; private set; }
    public bool IsBumpHead { get; private set; }
    public float GroundMoveProgress { get; private set; }
    public int NumberOfDashHadUsed { get; private set; }
    float speedBuff;
    float jumpBuff;
    bool isFacingRight = true;
    Rigidbody2D rigi;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        coll = this.GetComponent<Collider2D>();
    }
    void Update()
    {
        GroundArea = new Vector2(coll.bounds.center.x, coll.bounds.min.y);
        HeadArea = new Vector2(coll.bounds.center.x, coll.bounds.max.y);
        IsOnGround = Check(GroundArea, GroundCheckAreaSize, ground);
        IsOnWall = Check(WallCheckPoint.position, WallCheckAreaSize, wall);
        IsBumpHead = Check(HeadArea, HeadCheckAreaSize, ground);
        ChangeDirection();
        GetGroundMoveProgress();
    }

    

    public void Move(float maxSpeed, float acceleration, float deceleration)
    {
        float horizontalVelocity = rigi.velocity.x, verticalVelocity = rigi.velocity.y;

        if (InputManager.Instance.MoveDirection != 0)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, (maxSpeed + speedBuff) * InputManager.Instance.MoveDirection, acceleration * Time.deltaTime);
        }
        else horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, deceleration * Time.deltaTime);

        verticalVelocity = Mathf.Clamp(verticalVelocity, -playerData.MaxFallingSpeed, float.MaxValue);

        rigi.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }
    public void Jump()
    {
        rigi.velocity = new Vector2(rigi.velocity.x, playerData.JumpForce + jumpBuff);
    }
    public bool IsJumpDone() => (rigi.velocity.y <= 0f);
    public void GetGroundMoveProgress()
    {
        GroundMoveProgress = Mathf.InverseLerp(0, playerData.MaxGroundMovingSpeed, Mathf.Abs(rigi.velocity.x));
    }
    public void SetSpeedBuff(float value)
    {
        speedBuff = value;
    }
    public void SetJumpBuff(float value)
    {
        jumpBuff = value;
    }
    void ChangeDirection()
    {
        if (InputManager.Instance.MoveDirection > 0 && !isFacingRight)
        {
            isFacingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (isFacingRight && InputManager.Instance.MoveDirection < 0f)
        {
            isFacingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    bool Check(Vector2 point, Vector2 size, LayerMask layer)
    {
        return Physics2D.OverlapBox(point, size, 0, layer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 GA = new Vector2(coll.bounds.center.x, coll.bounds.min.y);
        Gizmos.DrawWireCube(GA, GroundCheckAreaSize);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(WallCheckPoint.position, WallCheckAreaSize);

        Gizmos.color = Color.blue;
        Vector2 HA = new Vector2(coll.bounds.center.x, coll.bounds.max.y);
        Gizmos.DrawWireCube(HA, HeadCheckAreaSize);
    }

    
}
// Em nên để cho mỗi state tự quyết định behaviour hay làm một hàm feature như này cung cấp cho state ạ :3