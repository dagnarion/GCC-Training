using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour,IOnItemDrop
{
    public void OnItemDrop(Item item)
    {
        item.transform.position = this.transform.position;
    }
}
