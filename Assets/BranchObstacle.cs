using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchObstacle : MonoBehaviour
{
    [SerializeField] private Collider2D BlockCollider;
    
    private void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            var playerController = other.gameObject.GetComponent<PlayerController>();

            BlockCollider.enabled = playerController._isGrounded;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            var playerController = other.gameObject.GetComponent<PlayerController>();

            BlockCollider.enabled = true;
        }
    }
}
