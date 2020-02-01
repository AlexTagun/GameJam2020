using UnityEngine;
using Zenject;

public class Bonfire : MonoBehaviour
{
    [Inject] private TemperatureManager _temperatureManager;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            _temperatureManager.GoToTemperatureFiller();
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            _temperatureManager.ExitFromTemperatureFiller();
        }
    }
}