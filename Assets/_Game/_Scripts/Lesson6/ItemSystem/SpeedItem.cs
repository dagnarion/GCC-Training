using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour,IItem
{
    [SerializeField] float buffAmount;
    [SerializeField] float buffTime;

    public string BuffType => "Speed";

    public float Value => buffAmount;

    public float Duration => buffTime;

    public void OnPickUp(GameObject player)
    {
        if (player == null) { Debug.Log("Not had PlayerInformation yet in "+this.gameObject.name); return; }
        player.GetComponent<PlayerMovement>().AddBuff(this);
        Debug.Log(this.gameObject.name + " Had Been Collected by " + player.name);
        this.gameObject.SetActive(false);
    }
}
