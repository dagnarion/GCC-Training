using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaa : MonoBehaviour
{
    float moveFlag;
    [SerializeField] float speed;
    void Update()
    {
        moveFlag = Input.GetAxisRaw("Horizontal");
        if (moveFlag != 0) transform.position += Vector3.right* moveFlag*speed*Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IShape>(out IShape shape))
        {
            shape.Talk();
        }
    }
}
