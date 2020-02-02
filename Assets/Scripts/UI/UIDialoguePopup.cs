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

    private Vector3 _screenCoords;

    private void Awake(){
        _eventManager.OnTextPopupShown += Show;

        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController = player;

        _screenCoords = Camera.main.WorldToScreenPoint(playerController.GetPointForDialogPopup.position);
    }

    private void Update(){
        transform.position = _screenCoords;
    }

    private void Show(string text){
        Text.text = text;
        
        Background.gameObject.SetActive(true);
        
        Invoke("Hide",2.5f);
    }

    private void Hide(){
        Background.gameObject.SetActive(false);
    }
}
