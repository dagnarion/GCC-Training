using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObj : MonoBehaviour
{
    [SerializeField] GameInit gameInit;
    // void Awake()
    // {
    //     Debug.Log("Awake");
    // }
    void Start()
    {
        Instantiate(gameInit);
    }
    // void OnEnable()
    // {
    //     Debug.Log("On Enable");
    // }
    // void Update()
    // {

    // }
    // void FixedUpdate()
    // {

    // }
    // void LateUpdate()
    // {
        
    // }
}
