using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] BuffDataSO buffData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if(collision.TryGetComponent<IEffectable>(out IEffectable obj))
        {
            obj.Add(buffData);
            this.gameObject.SetActive(false);
            return;
        }
    }
}
