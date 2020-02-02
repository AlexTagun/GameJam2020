using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITemperaturePanel : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private Image Background;


    public void UpdateView(float value) {
        if (0 <= value){
            Text.text = "+" + value.ToString() + " C";
        }
        else{
            Text.text = value.ToString() + " C";
        }
    }

    public void Show(){
        Text.DOFade(1f, 1f);
        Background.DOFade(1f, 1f);
    }
    
    public void Hide(){
        Text.DOFade(0f, 1f);
        Background.DOFade(0f, 1f);
    }
}
