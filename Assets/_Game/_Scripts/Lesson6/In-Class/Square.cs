using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour, IShape
{
    public void Talk()
    {
        Debug.Log("I'm Square");
    }
}
