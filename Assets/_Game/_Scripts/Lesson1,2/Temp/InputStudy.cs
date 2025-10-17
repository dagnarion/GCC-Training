using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStudy : MonoBehaviour
{
    
    void Update()
    {
        float moveFlag = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right* 5 * moveFlag * Time.deltaTime);
    }
}
