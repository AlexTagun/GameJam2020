using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TemperatureProgressBar : MonoBehaviour {
    [Inject] private EventManager _eventManager;

    [SerializeField] private Image FillImage;

    public void SetValue(float currentValue, float maxValue) {
        var fillAmount = currentValue / maxValue;

        FillImage.fillAmount = fillAmount;
    }
}
