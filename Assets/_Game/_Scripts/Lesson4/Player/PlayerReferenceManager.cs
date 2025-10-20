using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] MeleeAttack playerMeleeAttack;

    public PlayerController Controller => playerController;
    public MeleeAttack MeleeAttack => playerMeleeAttack;

    void Awake()
    {
        playerController = this.GetComponent<PlayerController>();
        playerMeleeAttack = this.GetComponent<MeleeAttack>();
    }
}
