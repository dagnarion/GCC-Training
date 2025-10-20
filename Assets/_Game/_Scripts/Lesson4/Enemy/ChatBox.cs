using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    SpriteRenderer sprite;

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        EnemyController.onPlayerEnter += CallChatBox;
    }

    void CallChatBox()
    {
        StartCoroutine(ChatBoxActive());
    }
    
    IEnumerator ChatBoxActive()
    {
        sprite.enabled = true;
        yield return new WaitForSeconds(2);
        sprite.enabled = false;
    }
}
