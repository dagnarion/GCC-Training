using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; protected set; }
    void Awake()
    {
        if (Instance == null) { Instance = this.GetComponent<T>(); return; }
        if (Instance.GetInstanceID() != this.GetInstanceID()) { Destroy(this); return; }
    }
}
