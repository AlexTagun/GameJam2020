using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void PutItem(TypeItem typeItem)
    {
        if (typeItem == TypeItem.wood)
            Debug.Log("Предмет дерево принят");
        if (typeItem == TypeItem.rock)
            Debug.Log("Предмет камень принят");
        if (typeItem == TypeItem.sand)
            Debug.Log("Предмет песок принят");
    }
}
