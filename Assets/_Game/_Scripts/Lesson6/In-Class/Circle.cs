using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour, IShape
{
    public void Talk()
    {
        Debug.Log("I'm Circle");
    }
}
