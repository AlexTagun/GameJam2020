using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour {
    [SerializeField] private bool DebugMode = false;
    [SerializeField] private UIGameController _uiGameController;
    [SerializeField] private GameObject _gameplayGO;
    [SerializeField] private UIMainMenu _mainMenu;

    [Inject] private EventManager _eventManager;
    [Inject] private TemperatureManager _temperatureManager;

    private void Awake() {
        _eventManager.OnStartGame += StartGame;
        _eventManager.OnMainMenu += ToMainMenu;
        if(!DebugMode) _eventManager.OnDefeat += ToMainMenu;
        
    }

    private void Start(){
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

        if(_temperatureManager.CurTimeToChangingGlobalTemperature >= _temperatureManager.IntervalChangingGlobalTemperature)
        {
            _temperatureManager.RemoveGlobalTemperature();
            _temperatureManager.CurTimeToChangingGlobalTemperature = 0f;
        }
        else
        {
            if (_eventManager.IsTutorialCompleted){
                _temperatureManager.CurTimeToChangingGlobalTemperature += Time.deltaTime;
            }
        }
            
    }
}
