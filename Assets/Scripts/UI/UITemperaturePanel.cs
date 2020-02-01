using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UITemperaturePanel : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI Text;
        


        public void UpdateView(float value){
            Text.text = value.ToString();
        }
    }
}