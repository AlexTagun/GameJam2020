using Zenject;

public class TemperatureManager
{
    [Inject] private EventManager _eventManager;

    public readonly float MAX_PLAYER_TEMPERATURE = 100f;

    public readonly float PLAYER_TEMPERATURE_REMOVING_VALUE = 0.1f;

    private float _currentGlobalTemperature;

    private float _currentPlayerTemperature;

    private bool _isPlayerFreezing = true;
    public bool IsPlayerFreezing => _isPlayerFreezing;

//    public void OnGlobalTemperatureChanged(float value){
//        _currentGlobalTemperature += value;
//    }

    public void Init(){
        FillPlayerTemperature();
    }

    public void RemovePlayerTemperature(float value){
        _currentPlayerTemperature -= value;
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);
    }

    private void FillPlayerTemperature(){
        _currentPlayerTemperature = MAX_PLAYER_TEMPERATURE;
        _eventManager.HandlePlayerTemperatureChanged(_currentPlayerTemperature);
    }

    public void GoToTemperatureFiller(){
        if (_isPlayerFreezing){
            _isPlayerFreezing = false;
            FillPlayerTemperature();
        }
    }

    public void ExitFromTemperatureFiller(){
        _isPlayerFreezing = true;
    }
}