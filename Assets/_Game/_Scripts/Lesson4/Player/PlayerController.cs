using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigi;
    Animator animator;
    public event Action onAttackPressed;
    enum State { moving, attack };
    State currentState = State.moving;

    [Header("Custom Move")]
    [SerializeField] float moveSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;
    float moveFlag;
    float horizontalVelocity;
    float attackDuration = 0.5f;
    bool isAttack = false;


    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Handle();
    }

    void Handle()
    {
        moveFlag = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.P) && !isAttack)
        {
            StartCoroutine(AttackCoroutine());
            isAttack = true;
        }
    }

    void FixedUpdate()
    {
        PlayState(currentState);
    }

    void PlayState(State state)
    {
        switch (state)
        {
            case State.moving:
                Move();
                break;
            case State.attack:
                StopMove();
                break;
        }
    }
    
    IEnumerator AttackCoroutine()
    {
        currentState = State.attack;
        animator.SetTrigger(CONSTANT.PlayerAttack);
        onAttackPressed?.Invoke();
        yield return new WaitForSeconds(attackDuration);
        currentState = State.moving;
        isAttack = false;
    }

    // hàm di chuyển và dừng theo gia tốc và giảm tốc
    void Move()
    {
        if (moveFlag != 0)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, moveSpeed * moveFlag, Time.fixedDeltaTime * acceleration);
        }
        else horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, deceleration * Time.fixedDeltaTime);
        animator.SetFloat(CONSTANT.PlayerMoving, Mathf.InverseLerp(0, moveSpeed, Mathf.Abs(horizontalVelocity)));
        ChangeDirection();
        SetVelocity();
    }

    void ChangeDirection()
    {
        if (moveFlag != 0) transform.localScale = new Vector3(-moveFlag, 1, 1);
    }

    // hàm dừng chuyển động khi player tấn công
    void StopMove()
    {
        horizontalVelocity = 0;
        SetVelocity();
    }

    // hàm set vận tốc player
    void SetVelocity()
    {
        rigi.velocity = new Vector2(horizontalVelocity, rigi.velocity.y);
    }

}