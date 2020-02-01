using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerCamera : MonoBehaviour {
    [SerializeField] private Transform _player;
    [SerializeField] private Animator animatorCamera;

    private void Update() {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }

    public void AnimShake()
    {
        animatorCamera.SetTrigger("Shake");
    }
}
