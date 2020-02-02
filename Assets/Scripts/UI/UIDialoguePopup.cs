using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIDialoguePopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Image Background;

    [SerializeField] private List<string> TutorialStrings;

    private int _tutoiralStringIndex = 0;

    [Inject] private EventManager _eventManager;

    private PlayerController playerController;

    private Vector3 _screenCoords;

    private void Awake(){
        _eventManager.OnTextPopupShown += Show;

        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        playerController = player;

        _screenCoords = Camera.main.WorldToScreenPoint(playerController.GetPointForDialogPopup.position);

        if (!_eventManager.IsTutorialCompleted && 0 < TutorialStrings.Count){
            Show(TutorialStrings[_tutoiralStringIndex]);
        }
    }

    private void Update(){
        transform.position = _screenCoords;

        if (!_eventManager.IsTutorialCompleted && Input.GetKeyDown(KeyCode.Space)){
            UpdateTutorial();
        }
    }

    private void Show(string text){
        Text.text = text;
        
        Background.gameObject.SetActive(true);

        if (_eventManager.IsTutorialCompleted){
            Invoke("Hide",2.5f);
        }
    }

    private void UpdateTutorial(){
        _tutoiralStringIndex++;

        if (_tutoiralStringIndex < TutorialStrings.Count){
            Show(TutorialStrings[_tutoiralStringIndex]);
        }
        else{
            _eventManager.IsTutorialCompleted = true;
            Hide();
        }
    }

    private void Hide(){
        Background.gameObject.SetActive(false);
    }
}
