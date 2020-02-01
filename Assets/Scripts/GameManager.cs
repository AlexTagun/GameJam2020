using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour {
    [SerializeField] private GamePlay _gamePlay;
    [SerializeField] private UIMainMenu _mainMenu;

    [Inject] private EventManager _eventManager;
    [Inject] private TemperatureManager _temperatureManager;

    private void Awake() {
        _eventManager.OnStartGame += StartGame;
        _eventManager.OnMainMenu += ToMainMenu;
        
        _temperatureManager.Init();
    }

    private void StartGame() {
        _mainMenu.Hide();
        _gamePlay.Show();
    }

    public void ToMainMenu() {
        _mainMenu.Show();
        _gamePlay.Hide();
    }

    private void Update(){
        if (_temperatureManager.IsPlayerFreezing){
            _temperatureManager.RemovePlayerTemperature(_temperatureManager.PLAYER_TEMPERATURE_REMOVING_VALUE);
        }
    }
}
