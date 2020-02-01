using System;
using UnityEngine;
using Zenject;

public class UIGameController : MonoBehaviour {
    [Inject] private EventManager _eventManager;
    [Inject] private TemperatureManager _temperatureManager;


    [SerializeField] private TemperatureProgressBar TemperatureProgressBar;
    [SerializeField] private UITemperaturePanel UiTemperaturePanel;

    private void Awake() {
        _eventManager.OnGlobalTemperatureChanged += OnGlobalTemperatureChanged;

        _eventManager.OnPlayerTemperatureChanged += OnPlayerTemperatureChanged;
    }

    private void OnGlobalTemperatureChanged(float value) {
        UiTemperaturePanel.UpdateView(value);
    }

    private void OnPlayerTemperatureChanged(float value) {
        TemperatureProgressBar.SetValue(value, _temperatureManager.MAX_PLAYER_TEMPERATURE);
    }

    public void Show() {
        
    }

    public void Hide() {
        Hide(null);
    }

    public void Hide(Action callback) {
        //TODO: wait for second
        callback?.Invoke();
    }
}
