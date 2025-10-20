using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{

    void Update()
    {
        Debug.Log("transform position: " + transform.position);
        Debug.Log("local Transform " + transform.localPosition);
    }
}
