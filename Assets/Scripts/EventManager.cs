using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
    public enum GameState {
        Play,
        Win,
        Defeat
    }

    public GameState gameState = GameState.Play;
    
    public Action OnStartGame = new Action(() => { });

    public void HandleStartGame() {
        OnStartGame?.Invoke();
    }

    public Action OnMainMenu = new Action(() => { });

    public void HandleMainMenu() {
        OnMainMenu?.Invoke();
    }

    public Action OnDefeat;

    public void HandleDefeat() {
        Debug.Log("Lose Game");
        gameState = GameState.Defeat;
        OnDefeat?.Invoke();
    }

    public Action<float> OnGlobalTemperatureChanged;

    public void HandleGlobalTemperatureChanged(float value) {
        OnGlobalTemperatureChanged?.Invoke(value);
    }

    public Action<float> OnPlayerTemperatureChanged;

    public void HandlePlayerTemperatureChanged(float value) {
        OnPlayerTemperatureChanged?.Invoke(value);
    }

    public Action OnItemPicked;

    public void HandleItemPicked(){
        OnItemPicked?.Invoke();
    }

    public Action OnItemPut;

    public void HandleItemPut(){
        OnItemPut?.Invoke();
    }
}
