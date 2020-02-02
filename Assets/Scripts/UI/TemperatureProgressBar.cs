using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using Zenject;

public class TemperatureProgressBar : MonoBehaviour {
    [Inject] private EventManager _eventManager;

    [SerializeField] private Image FillImage;
    [SerializeField] private Image Background;

    [SerializeField] private List<Sprite> Indicators;
    
    [SerializeField] private ParticleSystem _snowfall1;
    [SerializeField] private ParticleSystem _snowfall2;
    [SerializeField] private ParticleSystem _snowfall3;
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private Bloom _bloomLayer = null;
    private Vignette _vignetteLayer = null;
    
    private float _maxBloomIntensity = 18.45f;
    private float _minBloomIntensity = 0f;
    private float _maxVignetteIntensity = 1f;
    private float _minVignetteIntensity = 0.23f;

    private int _currentIndex = 0;
    
    private void Awake() {
        _postProcessVolume.profile.TryGetSettings(out _bloomLayer);
        _postProcessVolume.profile.TryGetSettings(out _vignetteLayer);
        _snowfall1.Stop();
        _snowfall2.Stop();
        _snowfall3.Stop();
    }

    public void SetValue(float currentValue, float maxValue) {
        _postProcessVolume.profile.TryGetSettings(out _bloomLayer);
        _postProcessVolume.profile.TryGetSettings(out _vignetteLayer);
        var fillAmount = currentValue / maxValue;
//
//        FillImage.fillAmount = fillAmount;

        var newIndex = CalculateIndicatorIndex(fillAmount);

        if (_currentIndex != newIndex){
//            Indicators[_currentIndex].DOFade(0f, 1f);
//            Indicators[newIndex].DOFade(1f, 1f);
            _currentIndex = newIndex;

            Background.DOFade(0.6f, 0.4f).OnComplete(() => {
                Background.sprite = Indicators[_currentIndex];
                Background.DOFade(1f, 0.4f);
            });
        }
        
        _bloomLayer.intensity.value = Mathf.Lerp(_minBloomIntensity, _maxBloomIntensity, 1 - fillAmount);
        _vignetteLayer.intensity.value = Mathf.Lerp(_minVignetteIntensity, _maxVignetteIntensity, 1 - fillAmount);

        if ((1 - fillAmount) < 0.33f) {
            _snowfall1.Play();
            _snowfall2.Stop();
            _snowfall3.Stop();
        }

        if ((1 - fillAmount) >= 0.33f && (1 - fillAmount) <= 0.66f) {
            _snowfall1.Play();
            _snowfall2.Play();
            _snowfall3.Stop();
        }
        
        if ((1 - fillAmount) >= 0.66f) {
            _snowfall1.Play();
            _snowfall2.Play();
            _snowfall3.Play();
        }
    }

    public void Show(){
//        Indicators[_currentIndex].DOFade(1f, 1f);
//        FillImage.DOFade(1f, 1f);
        Background.DOFade(1f, 1f);
    }

    public void Hide(){
//        Indicators[_currentIndex].DOFade(0f, 1f);
//        FillImage.DOFade(0f, 1f);
        Background.DOFade(0f, 1f);
    }

    private int CalculateIndicatorIndex(float currentValue){
        var indicatorIndex = 0;

        if (currentValue <= 0.05f){
            indicatorIndex = 5;
        }else if (currentValue <= 0.2f){
            indicatorIndex = 4;
        }else if (currentValue <= 0.4f){
            indicatorIndex = 3;
        }else if(currentValue <= 0.6f){
            indicatorIndex = 2;
        }else if (currentValue <= 0.8f){
            indicatorIndex = 1;
        }
        else{
            indicatorIndex = 0;
        }

        return indicatorIndex;
    }
}
