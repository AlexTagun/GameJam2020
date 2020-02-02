
using UnityEngine;
using Zenject;

public class Respawn : MonoBehaviour
{
    [Inject] private TemperatureManager _temperatureManager;
    [Inject] private EventManager _eventManager;

    private RespawnData _respawnData = new RespawnData();

    private void Awake(){
        _eventManager.OnDefeat += RespawnPlayer;
        _eventManager.OnItemPicked += UpdateRespawnData;
        _eventManager.OnItemPut += UpdateRespawnData;
    }

    private void Start(){
        UpdateRespawnData();
    }

    private void RespawnPlayer(){
        var playerGO = GameObject.FindWithTag("Player");
        playerGO.transform.position = _respawnData.PlayerPosition;
        
        _temperatureManager.SetPlayerTemperature(_temperatureManager.MAX_PLAYER_TEMPERATURE);
       // _temperatureManager.SetGlobalTemperature(_respawnData.GlobalTemperature);

        _eventManager.gameState = EventManager.GameState.Play;
    }

    private void UpdateRespawnData(){
        var playerGO = GameObject.FindWithTag("Player");
        var playerPosition = playerGO.transform.position;
        var globalTemperature = _temperatureManager.CurrentGlobalTemperature;
        
        SetRespawnData(playerPosition, globalTemperature);
    }

    private void SetRespawnData(Vector2 playerPosition, float globalTemperature){
        _respawnData.PlayerPosition = playerPosition;
        _respawnData.GlobalTemperature = globalTemperature;
    }
}