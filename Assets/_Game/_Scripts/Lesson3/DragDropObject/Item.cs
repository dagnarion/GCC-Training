using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask area;
    Vector2 OldPosition;
    Camera cam;
    void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        OldPosition = transform.position;
        transform.position = GetWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = GetWorldPosition();
    }

    void OnMouseUp()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, checkRadius,area);
        if (coll != null && coll.TryGetComponent(out IOnItemDrop dropArea))
        {
            dropArea.OnItemDrop(this);
        }
        else
        {
            transform.position = OldPosition;
        }

    }

    Vector3 GetWorldPosition()
    {
        Vector3 temp = cam.ScreenToWorldPoint(Input.mousePosition);
        temp.z = 0;
        return temp;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
// có thể làm mượt quá trình trở về vị trí cũ bằng lerp , trong lúc trở về thì tắt collider
// custom tùy game design
