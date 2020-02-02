using System;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class UIGameController : MonoBehaviour {
    [Inject] private EventManager _eventManager;
    [Inject] private TemperatureManager _temperatureManager;


    [SerializeField] private TemperatureProgressBar TemperatureProgressBar;
    [SerializeField] private UITemperaturePanel UiTemperaturePanel;
    [SerializeField] private VideoClip _winClip;
    [SerializeField] private VideoClip _defeatClip;
    [SerializeField] private VideoPlayer _videoPlayer;
    [SerializeField] private GameObject[] _objectsToHide;

    private void Awake() {
        _eventManager.OnGlobalTemperatureChanged += OnGlobalTemperatureChanged;

        _eventManager.OnPlayerTemperatureChanged += OnPlayerTemperatureChanged;

        _eventManager.OnStartGame += Show;
        _eventManager.OnWin += OnWin;
        _eventManager.OnDefeat += OnDefeat;
    }

    private void OnGlobalTemperatureChanged(float value) {
        UiTemperaturePanel.UpdateView(value);
    }

    private void OnPlayerTemperatureChanged(float value) {
        TemperatureProgressBar.SetValue(value, _temperatureManager.MAX_PLAYER_TEMPERATURE);
    }

    public void Show() {
        TemperatureProgressBar.Show();
        UiTemperaturePanel.Show();
    }

    public void Hide() {
        TemperatureProgressBar.Hide();
        UiTemperaturePanel.Hide();
        
        
        Hide(null);
    }

    public void Hide(Action callback) {
        //TODO: wait for second
        callback?.Invoke();
    }

    private void OnWin() {
        Hide();
        foreach (var obj in _objectsToHide) {
            obj.SetActive(false);
        }
        _videoPlayer.gameObject.SetActive(true);
        _videoPlayer.clip = _winClip;
        _videoPlayer.Play();
    }
    
    private void OnDefeat() {
        Hide();
        foreach (var obj in _objectsToHide) {
            obj.SetActive(false);
        }
        // Debug.Log("defeat");
        _videoPlayer.gameObject.SetActive(true);
        _videoPlayer.clip = _defeatClip;
        _videoPlayer.Play();
    }
}
