using UnityEngine;
using Zenject;

public class Item : MonoBehaviour
{
    [Inject] private EventManager _eventManager;
    
    
    public TypeItem typeItem;
    public void PickItem(Item item)
    {
        _eventManager.HandleItemPicked();
        
        Destroy(item.gameObject);
    }
}

public enum TypeItem
{
    wood, rock, sand
};
