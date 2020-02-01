using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Rocket rocket;
    
    private bool isAbleToPickItem = false;
    private Item itemNearPlayer;
    private TypeItem typePickedItem;

    private bool isAbleToPutItem = false;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Item") {
            Debug.Log("нажмите Е, чтобы подобрать");
            isAbleToPickItem = true;
            itemNearPlayer = other.gameObject.GetComponent<Item>();
        }
        
        if (other.gameObject.tag == "Rocket") {
            Debug.Log("Нажмите E, чтобы сдать");
            isAbleToPutItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Item") {
            Debug.Log("Подойдите к объекту");
            isAbleToPickItem = false;
        }

        if (other.gameObject.tag == "Rocket") {
            Debug.Log("Подойдите к объекту");
            isAbleToPutItem = false;
        }
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isAbleToPickItem) {
                typePickedItem = itemNearPlayer.typeItem;
                itemNearPlayer.PickItem(itemNearPlayer);
                isAbleToPickItem = false;
            }

            if (isAbleToPutItem) {
                rocket.PutItem(typePickedItem);
                isAbleToPutItem = false;
            }
        }
    }
}
