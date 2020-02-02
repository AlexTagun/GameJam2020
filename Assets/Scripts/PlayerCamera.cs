using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public class PlayerCamera : MonoBehaviour {
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerController pc;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float timeShake;
    [SerializeField] private float strenghtShake;

    private void Update() {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);
    }

    public void AnimShake()
    {
        Debug.Log("Камера трясется...");
        pc.SetSpeedModifier(0.0f);
        playerAnimator.enabled = false;
        Camera.main.DOShakePosition(timeShake, strenghtShake).OnComplete(() => {
            pc.ClearSpeedModifier();
            playerAnimator.enabled = true;
        });


    }
}
