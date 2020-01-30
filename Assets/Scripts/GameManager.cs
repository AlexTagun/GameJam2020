using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour {
    [SerializeField] private GamePlay _gamePlay;
    [SerializeField] private UIMainMenu _mainMenu;

    [Inject] private EventManager _eventManager;

    private void Awake() {
        _eventManager.OnStartGame += StartGame;
        _eventManager.OnMainMenu += ToMainMenu;
    }

    private void StartGame() {
        _mainMenu.Hide();
        _gamePlay.Show();
    }

    public void ToMainMenu() {
        _mainMenu.Show();
        _gamePlay.Hide();
    }
}
