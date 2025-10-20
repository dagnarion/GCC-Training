using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IAttackable
{
    Rigidbody2D rigi;
    Animator animator;
    CircleCollider2D checkCollider;
    public static event Action onPlayerEnter;
    float takeDameDelay = 0.2f;
    float takeDameTimer;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponentInChildren<Animator>();
        checkCollider = this.GetComponentInChildren<CircleCollider2D>();
    }
    void Start()
    {
        rigi.isKinematic = true;
    }
    void Update()
    {
        takeDameDelay = Mathf.Clamp(takeDameTimer - Time.deltaTime, 0, float.MaxValue);
    }

    // Check xem player đã đi vào vùng hiện chatBox hay chưa
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        StartCoroutine(TalkDone());
        onPlayerEnter?.Invoke();
    }

    IEnumerator TalkDone()
    {
        checkCollider.enabled = false;
        yield return new WaitForSeconds(2);
        rigi.isKinematic = false;
    }

    // nhận lực tác dụng từ player
    public void TakeForce(float force, Vector2 Direction)
    {
        if (takeDameTimer <= 0)
        {
            if(rigi.isKinematic == false) animator.SetTrigger("Hit");
            rigi.AddForce(Direction * force);
            takeDameTimer = takeDameDelay;
        }
    }


}
