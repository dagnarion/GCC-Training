using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
   public float MoveDirection { get; private set; }
   public bool IsJumpPress { get; private set; }
   public bool IsJumpRelease { get; private set; }
    public static event Action Attack;
    void Update()
    {
        Handle();
    }
    
    void Handle()
    {
        MoveDirection = Input.GetAxisRaw("Horizontal");
        IsJumpPress = Input.GetKeyDown(KeyCode.Space);
        IsJumpRelease = Input.GetKeyUp(KeyCode.Space);
        if (Input.GetKeyDown(KeyCode.J)) { Attack?.Invoke(); }
    }
}
