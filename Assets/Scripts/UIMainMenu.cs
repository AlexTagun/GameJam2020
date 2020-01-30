using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIMainMenu : MonoBehaviour {
    [SerializeField] private Button _startButton;

    [Inject] private EventManager _eventManager;

    private void Awake() {
        _startButton.onClick.AddListener(OnStart);
    }

    private void OnStart() {
        Hide();
        _eventManager.HandleStartGame();
    }

    private void Show() {
        
    }

    private void Hide() {
        
    }
}
