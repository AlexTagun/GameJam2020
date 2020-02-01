using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Rocket : MonoBehaviour
{
    [Inject] private EventManager _eventManager;
    
     public void PutItem(TypeItem typeItem)
    {
        if (typeItem == TypeItem.wood)
            Debug.Log("Предмет дерево принят");
        if (typeItem == TypeItem.rock)
            Debug.Log("Предмет камень принят");
        if (typeItem == TypeItem.sand)
            Debug.Log("Предмет песок принят");
        
        _eventManager.HandleItemPut();
    }
}
