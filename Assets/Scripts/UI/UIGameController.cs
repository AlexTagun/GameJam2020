using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    
    [SerializeField] private Image _back;

    private void Awake() {
        _eventManager.OnGlobalTemperatureChanged += OnGlobalTemperatureChanged;

        _eventManager.OnPlayerTemperatureChanged += OnPlayerTemperatureChanged;

        _eventManager.OnStartGame += Show;
        _eventManager.OnWin += OnWin;
        _eventManager.OnDefeat += OnDefeat;

        _videoPlayer.loopPointReached += RestartGame;
    }

    private void OnGlobalTemperatureChanged(float value) {
        UiTemperaturePanel.UpdateView(value);
    }

    private void RestartGame(VideoPlayer videoPlayer){
        var currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
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
    
    IEnumerator FadeOutBack() {
        yield return new WaitForSeconds(0.5f);
        _back.DOFade(0, 0.5f);
        yield return new WaitForSeconds(41.0f);
        _back.DOFade(1, 0);
        yield return new WaitForSeconds(1.5f);
        foreach (var obj in _objectsToHide) {
            obj.SetActive(true);
        }
        TemperatureProgressBar.Show();
        UiTemperaturePanel.Show();
        _back.DOFade(0, 1f);
    }
}
