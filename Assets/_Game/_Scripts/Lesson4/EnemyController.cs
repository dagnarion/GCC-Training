using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyController : MonoBehaviour,IAttackable
{
    Rigidbody2D rigi;
    [SerializeField] GameObject chatBox;
    [SerializeField] GameObject chatBoxCollider;
    void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rigi.isKinematic = true;
    }

    // Check xem player đã đi vào vùng hiện chatBox hay chưa
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        StartCoroutine(ChatBoxActive());
    }

    // Coroutine đóng,hiện chatBox
    IEnumerator ChatBoxActive()
    {
        chatBox.SetActive(true);
        chatBoxCollider.SetActive(false);
        yield return new WaitForSeconds(1);
        chatBox.SetActive(false);
        rigi.isKinematic = false;
    }

    // nhận lực tác dụng từ player
    public void TakeForce(float force,Vector2 Direction)
    {
        rigi.AddForce(force * Direction,ForceMode2D.Impulse);
    }
}
