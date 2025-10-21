using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    [SerializeField] EnemyReferenceManager enemyReference;
    SpriteRenderer sprite;

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        enemyReference = this.GetComponentInParent<EnemyReferenceManager>();
    }

    void OnEnable()
    {
        enemyReference.enemyController.onPlayerEnter += CallChatBox;
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
