using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLootSystem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IItem>(out IItem items))
        {
            items.OnPickUp(this.transform.parent.gameObject);
        }
    }
}
