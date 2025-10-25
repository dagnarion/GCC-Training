using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "PlayerSo",fileName = "PLayerHP")]
public class PlayerSO : ScriptableObject
{
    public int HP;
    public void Hello()
    {
        Debug.Log("Hello");
    }
}
