using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
    
    public Action OnStartGame = new Action(() => {});

    public void HandleStartGame() {
        OnStartGame?.Invoke();
    }
    
    public Action OnMainMenu = new Action(() => {});

    public void HandleMainMenu() {
        OnMainMenu?.Invoke();
    }

    public Action OnLoseGame;

    public void HandleLoseGame(){
        Debug.Log("Lose Game");
        OnLoseGame?.Invoke();
    }

    public Action<float> OnGlobalTemperatureChanged;

    public void HandleGlobalTemperatureChanged(float value){
        OnGlobalTemperatureChanged?.Invoke(value);
    }

    public Action<float> OnPlayerTemperatureChanged;
    
    public void HandlePlayerTemperatureChanged(float value){
        OnPlayerTemperatureChanged?.Invoke(value);
    }
}
