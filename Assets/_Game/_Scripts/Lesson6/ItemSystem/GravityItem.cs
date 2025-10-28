using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityItem : MonoBehaviour, IItem
{
    [SerializeField] float gravityChange;
    [SerializeField] float timeLeft;
    public string BuffType => "Gravity";

    public float Value => gravityChange;

    public float Duration => timeLeft;

    public void OnPickUp(GameObject player)
    {
       if (player == null) { Debug.Log("Not had PlayerInformation yet in "+this.gameObject.name); return; }
        player.GetComponent<PlayerMovement>().AddBuff(this);
        this.gameObject.SetActive(false);
    }
}
