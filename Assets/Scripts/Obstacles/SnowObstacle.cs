using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowObstacle : MonoBehaviour
{
    [SerializeField] private readonly float SNOW_SPEED_MODIFIER = 0.3f;
    
    private void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            var playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController._isGrounded){
                playerController.SetSpeedModifier(SNOW_SPEED_MODIFIER);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            var playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.ClearSpeedModifier();
        }
    }
}
