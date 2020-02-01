﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Rocket rocket;

    [Inject] private EventManager _eventManager;
    
    private bool isAbleToPickItem = false;
    private Item itemNearPlayer;
    private TypeItem typePickedItem;

    private bool isAbleToPutItem = false;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Item") {
            Debug.Log("нажмите Е, чтобы подобрать");
            isAbleToPickItem = true;
            itemNearPlayer = other.gameObject.GetComponent<Item>();
            _eventManager.HandleTextItemCollectorHelpShown();
        }
        
        if (other.gameObject.tag == "Rocket") {
            if (isAbleToPutItem)
            {
                rocket.PutItem(typePickedItem);
                isAbleToPutItem = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Item") {
            Debug.Log("Подойдите к объекту");
            isAbleToPickItem = false;
            _eventManager.HandleTextItemCollectorHelpHidden();
        }

        /* if (other.gameObject.tag == "Rocket") {
            Debug.Log("Подойдите к объекту");
            isAbleToPutItem = false;
        } */
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isAbleToPickItem) {
                typePickedItem = itemNearPlayer.typeItem;
                itemNearPlayer.PickItem(itemNearPlayer);
                isAbleToPickItem = false;
                isAbleToPutItem = true;
                _eventManager.HandleTextItemCollectorHelpHidden();
            }

           /* if (isAbleToPutItem) {
                rocket.PutItem(typePickedItem);
                isAbleToPutItem = false;
            } */
        }
    }
}
