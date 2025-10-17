using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    Camera cam;
    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ObjectTracking();
        }
    }
    void ObjectTracking()
    {
        Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        if (hit.collider == null) return;
        SpriteRenderer cellSprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
        if (cellSprite.enabled == true) return;
        cellSprite.enabled = true;
    }
}
