using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DialogueMarker : MonoBehaviour
{
    [SerializeField] private string Text;

    [Inject] private EventManager _eventManager;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            _eventManager.HandleTextPopupShown(Text);
            Destroy(gameObject);
        }
    }
}
