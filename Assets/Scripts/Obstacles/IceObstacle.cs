using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceObstacle : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            playerController._isOnIce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            playerController._isOnIce = false;
        }
    }
}
