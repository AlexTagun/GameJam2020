using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TemperatureProgressBar : MonoBehaviour {
    [Inject] private EventManager _eventManager;

    [SerializeField] private Image FillImage;
    [SerializeField] private Image Background;

    [SerializeField] private List<Sprite> Indicators;

    private int _currentIndex = 0;

    public void SetValue(float currentValue, float maxValue) {
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
