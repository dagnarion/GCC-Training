using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    Rigidbody2D rigi;
    float vertiFlag, horizonFlag;
    [Header("Custom velocity")]
    [SerializeField] float moveForce;
    [SerializeField] float deceleration;
    int moveModeCount;
    enum MoveMode
    {
        Velocity, AddForce
    }
    MoveMode currentMode = MoveMode.Velocity;
    #region Reference
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Init
    void Start()
    {
        moveModeCount = Enum.GetNames(typeof(MoveMode)).Length;
    }
    #endregion

    #region  Handle
    void Update()
    {
        Handle();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchMode();
        }
    }
    void Handle()
    {
        vertiFlag = Input.GetAxis("Vertical");
        horizonFlag = Input.GetAxis("Horizontal");
    }
    #endregion
    
    #region  Move
    void FixedUpdate()
    {
        RunMode(currentMode);
    }
    void SwitchMode()
    {
        currentMode++;
        if ((int)currentMode >= moveModeCount)
        {
            currentMode = 0;
        }
        Debug.Log("Move By: " + currentMode.ToString());
    }
    void RunMode(MoveMode move)
    {
        switch (move)
        {
            case MoveMode.Velocity:
                MoveBySetVelocity();
                break;
            case MoveMode.AddForce:
                MoveByAddForce();
                break;
        }
    }
    void MoveBySetVelocity()
    {
        rigi.velocity = new Vector2(horizonFlag, vertiFlag) * moveForce;
    }
    void MoveByAddForce()
    {
        Vector2 Direction = new Vector2(horizonFlag, vertiFlag);
        if (Direction == Vector2.zero)
        {
            Vector2 targetVel = rigi.velocity;
            targetVel.x = Mathf.Lerp(targetVel.x, 0, Time.fixedDeltaTime * deceleration);
            targetVel.y = Mathf.Lerp(targetVel.y, 0, Time.fixedDeltaTime * deceleration);
            rigi.velocity = targetVel;
            return;
        }
        rigi.AddForce(Direction * moveForce, ForceMode2D.Force);
    }
    #endregion
}
