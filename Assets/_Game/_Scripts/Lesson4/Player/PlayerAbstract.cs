using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour
{
    protected PlayerReferenceManager playerReference;
    void Awake()
    {
        playerReference = this.GetComponent<PlayerReferenceManager>();
    }

}
