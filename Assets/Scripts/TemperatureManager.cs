using UnityEngine;
using Zenject;

public class TemperatureManager
{
    [Inject] private EventManager _eventManager;

    public readonly float MAX_PLAYER_TEMPERATURE = 100f;

    private readonly float REMOVING_PLAYER_TEMPERATURE_VALUE = 0.07f;
    private readonly float ADDING_PLAYER_TEMPERATURE_VALUE = 1f;

    private readonly float START_GLOBAL_TEMPERATURE_VALUE = 10f;
    private readonly float REMOVING_GLOBAL_TEMPERATURE_VALUE = 1f;
    public readonly float DEFEAT_GLOBAL_TEMPERATURE_VALUE = -120f;

    [SerializeField] private float intervalChangingGlobalTemperature = 5f;
    public float IntervalChangingGlobalTemperature => intervalChangingGlobalTemperature;

    private float curTimeToChangingGlobalTemperature;
    //public float CurTimeToChangingGlobalTemperature => curTimeToChangingGlobalTemperature;
    public float CurTimeToChangingGlobalTemperature 
    {
        get { return curTimeToChangingGlobalTemperature; }
        set { curTimeToChangingGlobalTemperature = value; }
    }

    private float _currentGlobalTemperature;
    public float CurrentGlobalTemperature => _currentGlobalTemperature;

    private float _currentPlayerTemperature;

    private bool _isPlayerFreezing = true;
    public bool IsPlayerFreezing => _isPlayerFreezing;

    public void Init(){
        SetPlayerTemperature(MAX_PLAYER_TEMPERATURE);
        SetGlobalTemperature(START_GLOBAL_TEMPERATURE_VALUE);
    }

    public void SetGlobalTemperature(float value){
        _currentGlobalTemperature = value;
        _eventManager.HandleGlobalTemperatureChanged(_currentGlobalTemperature);
    }
    
    public void SetPlayerTemperature(float value){
        _currentPlayerTemperature = value;
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);
    }
    
    public void RemovePlayerTemperature(){
        _currentPlayerTemperature -= REMOVING_PLAYER_TEMPERATURE_VALUE;
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);

        if (_currentPlayerTemperature <= 0f && _eventManager.gameState != EventManager.GameState.Defeat){
            _eventManager.HandleDefeat();
        }
    }

    public void AddPlayerTemperature(){
        if (MAX_PLAYER_TEMPERATURE <= _currentPlayerTemperature){
            _currentPlayerTemperature = MAX_PLAYER_TEMPERATURE;
            return;
        }
        
        _currentPlayerTemperature += ADDING_PLAYER_TEMPERATURE_VALUE;
        
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);
    }

    public void RemoveGlobalTemperature()
    {
        _currentGlobalTemperature -= REMOVING_GLOBAL_TEMPERATURE_VALUE;
        _eventManager.HandleGlobalTemperatureChanged(_currentGlobalTemperature);
    }

    public void GoToTemperatureFiller(){
        _isPlayerFreezing = false;
    }

    public void ExitFromTemperatureFiller(){
        _isPlayerFreezing = true;
    }
}