using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour {
    [SerializeField] private UIGameController _uiGameController;
    [SerializeField] private GameObject _gameplayGO;
    [SerializeField] private UIMainMenu _mainMenu;

    [Inject] private EventManager _eventManager;
    [Inject] private TemperatureManager _temperatureManager;

    private void Awake() {
        _eventManager.OnStartGame += StartGame;
        _eventManager.OnMainMenu += ToMainMenu;
        _eventManager.OnDefeat += ToMainMenu;
        
        _temperatureManager.Init();
    }

    private void StartGame() {
        _mainMenu.Hide();
        _gameplayGO.SetActive(true);
    }

    public void ToMainMenu() {
        _mainMenu.Show();
        _uiGameController.Hide(() => { _gameplayGO.SetActive(false); });
    }

    private void Update(){
        if (_temperatureManager.IsPlayerFreezing){
            _temperatureManager.RemovePlayerTemperature();
        }
        else{
            _temperatureManager.AddPlayerTemperature();
        }
    }
}
