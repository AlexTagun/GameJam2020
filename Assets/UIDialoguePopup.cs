using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIDialoguePopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Image Background;

    [Inject] private EventManager _eventManager;

    private PlayerController playerController;

    private void Awake(){
        _eventManager.OnTextPopupShown += Show;

        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController = player;

    }

    private void Update(){
        var screenCoords = Camera.main.WorldToScreenPoint(playerController.GetPointForDialogPopup.position);
        transform.position = screenCoords;
    }

    private void Show(string text){
        Text.text = text;
        
        Background.gameObject.SetActive(true);
    }

    private void Hide(){
        Background.gameObject.SetActive(false);
    }
}
