﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class PlayerController : MonoBehaviour {
    [Inject] private EventManager _eventManager;

    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;
    [SerializeField] private float FREEZING_PLAYER_TIME = 1f;
    [SerializeField] private Transform _jumpObject;
    [SerializeField] private SpriteRenderer IceCubeObject;
    [SerializeField] private RuntimeAnimatorController playerWithoutBagAnimator;
    [SerializeField] private RuntimeAnimatorController playerWithBagAnimator;
    [SerializeField] private Animator curAnimator;

    [SerializeField] private Transform PointForDialogPopup;
    public Transform GetPointForDialogPopup => PointForDialogPopup;

    [SerializeField] private Transform PointForItemCollectorHelp;
    public Transform GetPointForItemCollectorHelp => PointForItemCollectorHelp;

    private int lastMoveKeyUp = 2;

    public bool _isGrounded = true;
    public bool _isOnIce = false;
    private float _startVisualY;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private float _speedModifier = 1f;

    void Start() {
        _startVisualY = _jumpObject.localPosition.y;
        rb = GetComponent<Rigidbody2D>();
        curAnimator.runtimeAnimatorController = playerWithoutBagAnimator;
        _eventManager.OnItemPicked += ChangeAnimator;
        _eventManager.OnItemPut += ChangeAnimator;
    }


    void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        moveInput.x *= speedX * _speedModifier;
        moveInput.y *= speedY * _speedModifier;
        Debug.Log(_speedModifier);

        moveVelocity = moveInput;
        if (!_isGrounded) return;

        LastKeyMoveUp();
        if (!KeyMovePressed()) {
            //Debug.Log(LastKeyMoveUp());
            curAnimator.SetInteger("Idle", LastKeyMoveUp());
        } else {
            curAnimator.SetInteger("Idle", 0);
        }


        Vector2 vectorAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        curAnimator.SetFloat("Horizontal", vectorAxis.x);
        curAnimator.SetFloat("Vertical", vectorAxis.y);
        curAnimator.SetFloat("Magnitude", vectorAxis.magnitude);

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void FixedUpdate() {
        if (_isOnIce) {
            rb.AddForce(moveVelocity * 0.01f, ForceMode2D.Impulse);
        } else {
            rb.velocity = moveVelocity;
        }
    }

    private void Jump() {
        Debug.Log("Jump");
        _isGrounded = false;
        _jumpObject.DOLocalMoveY(_startVisualY + _jumpHeight, _jumpTime / 2).OnComplete(() => {
            _jumpObject.DOLocalMoveY(_startVisualY, _jumpTime / 2).OnComplete(() => {
                _isGrounded = true;
            });
        });
    }

    public void SetSpeedModifier(float value) {
        _speedModifier = value;
    }

    public void ClearSpeedModifier() {
        _speedModifier = 1f;
    }

    bool KeyMovePressed() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
            return true;
        }

        return false;
    }

    int LastKeyMoveUp() {
        if (Input.GetKeyUp(KeyCode.W)) {
            lastMoveKeyUp = 1;
        }

        if (Input.GetKeyUp(KeyCode.S)) {
            lastMoveKeyUp = 2;
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            lastMoveKeyUp = 3;
        }

        if (Input.GetKeyUp(KeyCode.A)) {
            lastMoveKeyUp = 4;
        }

        return lastMoveKeyUp;
    }

    void ChangeAnimator() {
        if (curAnimator.runtimeAnimatorController == playerWithoutBagAnimator) {
            curAnimator.runtimeAnimatorController = playerWithBagAnimator;
        } else if (curAnimator.runtimeAnimatorController == playerWithBagAnimator) {
            curAnimator.runtimeAnimatorController = playerWithoutBagAnimator;
        }
    }

    public void StartFreezCoroutine() {
        StartCoroutine(StartFreezing());
    }
    
    private IEnumerator StartFreezing() {
        IceCubeObject.gameObject.SetActive(true);
        IceCubeObject.DOFade(1, 0.2f);
        // var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SetSpeedModifier(0f);
        
        
        yield return new WaitForSeconds(FREEZING_PLAYER_TIME - 0.2f);
        IceCubeObject.DOFade(0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        IceCubeObject.gameObject.SetActive(false);
        SetSpeedModifier(1f);
        // _isReloaded = true;
    }
}
