using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReferenceManager : MonoBehaviour
{
   public EnemyController enemyController { get; private set; }
    void Awake()
    {
        enemyController = this.GetComponent<EnemyController>();
    }
}
