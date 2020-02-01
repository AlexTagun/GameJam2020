using Zenject;

public class TemperatureManager
{
    [Inject] private EventManager _eventManager;

    public readonly float MAX_PLAYER_TEMPERATURE = 100f;

    private readonly float REMOVING_PLAYER_TEMPERATURE_VALUE = 0.1f;
    private readonly float ADDING_PLAYER_TEMPERATURE_VALUE = 1f;

    private readonly float START_GLOBAL_TEMPERATURE_VALUE = -1f;

    private float _currentGlobalTemperature;

    private float _currentPlayerTemperature;

    private bool _isPlayerFreezing = true;
    public bool IsPlayerFreezing => _isPlayerFreezing;

    public void Init(){
        SetPlayerTemperature(MAX_PLAYER_TEMPERATURE);
        SetGlobalTemperature(START_GLOBAL_TEMPERATURE_VALUE);
    }

    private void SetGlobalTemperature(float value){
        _currentGlobalTemperature = value;
        _eventManager.HandleGlobalTemperatureChanged(_currentGlobalTemperature);
    }
    
    private void SetPlayerTemperature(float value){
        _currentPlayerTemperature = value;
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);
    }
    
    public void RemovePlayerTemperature(){
        _currentPlayerTemperature -= REMOVING_PLAYER_TEMPERATURE_VALUE;
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);

        if (_currentPlayerTemperature <= 0f){
            _eventManager.HandleLoseGame();
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

    public void GoToTemperatureFiller(){
        _isPlayerFreezing = false;
    }

    public void ExitFromTemperatureFiller(){
        _isPlayerFreezing = true;
    }
}