using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TemperatureProgressBar : MonoBehaviour {
    [Inject] private EventManager _eventManager;

    [SerializeField] private Image FillImage;
    [SerializeField] private Image Background;

    public void SetValue(float currentValue, float maxValue) {
        var fillAmount = currentValue / maxValue;

        FillImage.fillAmount = fillAmount;
    }

    public void Show(){
        FillImage.DOFade(1f, 1f);
        Background.DOFade(1f, 1f);
    }

    public void Hide(){
        FillImage.DOFade(0f, 1f);
        Background.DOFade(0f, 1f);
    }
}
