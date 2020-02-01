using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class ItemCollectorHelp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    
    [Inject] private EventManager _eventManager;
    
    private PlayerController playerController;

    private void Awake(){
        _eventManager.OnTextItemCollectorHelpShown += Show;
        _eventManager.OnTextItemCollectorHelpHidden += Hide;

        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController = player;
    }
    
    private void Update(){
        var screenCoords = Camera.main.WorldToScreenPoint(playerController.GetPointForItemCollectorHelp.position);
        transform.position = screenCoords;
    }

    private void Show(){
        Text.gameObject.SetActive(true);
    }

    private void Hide(){
        Text.gameObject.SetActive(false);
    }
}
