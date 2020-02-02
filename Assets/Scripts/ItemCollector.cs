using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Rocket rocket;

    [Inject] private EventManager _eventManager;
    
    private bool isAbleToPickItem = false;
    private Item itemNearPlayer;
    private TypeItem typePickedItem = TypeItem.none;

    private bool isAbleToPutItem = false;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Item") {
            //Debug.Log("нажмите Е, чтобы подобрать");
            isAbleToPickItem = true;
            itemNearPlayer = other.gameObject.GetComponent<Item>();
            _eventManager.HandleTextItemCollectorHelpShown();
        }
        
        if (other.gameObject.tag == "Rocket") {
            if (typePickedItem != TypeItem.none)
            {
                _eventManager.HandleTextItemCollectorHelpShown();
                isAbleToPutItem = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Item") {
            //Debug.Log("Подойдите к объекту");
            isAbleToPickItem = false;
            itemNearPlayer = null;
            _eventManager.HandleTextItemCollectorHelpHidden();
        }

         if (other.gameObject.tag == "Rocket") {
            //Debug.Log("Подойдите к объекту");
            _eventManager.HandleTextItemCollectorHelpHidden();
            isAbleToPutItem = false;
         } 
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isAbleToPickItem) {
                typePickedItem = itemNearPlayer.typeItem;
                itemNearPlayer.PickItem(itemNearPlayer);
                isAbleToPickItem = false;
                _eventManager.HandleTextItemCollectorHelpHidden();
            }
            if (isAbleToPutItem) {
                if (typePickedItem != TypeItem.none)
                {
                    rocket.PutItem(typePickedItem);
                    typePickedItem = TypeItem.none;
                    isAbleToPutItem = false;
                }
            } 
        }
    }
}
