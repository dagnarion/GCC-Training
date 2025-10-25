using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformTest : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] float changeValue;
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.color = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F),1);
    }
}
