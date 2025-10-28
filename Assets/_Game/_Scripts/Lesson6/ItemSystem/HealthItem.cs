using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour, IItem
{
    [SerializeField] int healthAmount;

    public string BuffType => "Health";
    public float Value => healthAmount;
    public float Duration => 0;

    public void OnPickUp(GameObject player)
    {
        if (player == null) { Debug.Log("Not had PlayerInformation yet in "+this.gameObject.name); return; }
        player.GetComponent<PlayerHealth>().Add(healthAmount);
        Debug.Log(this.gameObject.name + " Had Been Collected by " + player.name);
        this.gameObject.SetActive(false);
    }
}
