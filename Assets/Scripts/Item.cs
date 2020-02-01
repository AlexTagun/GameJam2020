using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public TypeItem typeItem;
    public void PickItem(Item item)
    {
        Destroy(item.gameObject);
    }
}

public enum TypeItem
{
    wood, rock, sand
};
