using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;
    [SerializeField] private Transform _visual;
    [SerializeField] private Animator playerAnimator;

    private int lastMoveKeyUp = 2;

    public bool _isGrounded = true;
    private float _startVisualY;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private float _speedModifier = 1f;

    void Start() {
        _startVisualY = _visual.localPosition.y;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal") * (speedX * _speedModifier), Input.GetAxisRaw("Vertical") * (speedY * _speedModifier));
        moveVelocity = moveInput;
        if(!_isGrounded) return;

        LastKeyMoveUp();
        if (!KeyMovePressed())
        {
            //Debug.Log(LastKeyMoveUp());
            playerAnimator.SetInteger("Idle", LastKeyMoveUp());
        }
        else
        {
            playerAnimator.SetInteger("Idle", 0);
        }


        Vector2 vectorAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerAnimator.SetFloat("Horizontal", vectorAxis.x);
        playerAnimator.SetFloat("Vertical", vectorAxis.y);
        playerAnimator.SetFloat("Magnitude", vectorAxis.magnitude);
        
        if(Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void Jump() {
        Debug.Log("Jump");
        _isGrounded = false;
        _visual.DOLocalMoveY(_startVisualY + _jumpHeight, _jumpTime / 2).OnComplete(() => {
            _visual.DOLocalMoveY(_startVisualY, _jumpTime / 2).OnComplete(() => {
                _isGrounded = true;
            });
        });
    }

    public void SetSpeedModifier(float value){
        _speedModifier = value;
    }

    public void ClearSpeedModifier(){
        _speedModifier = 1f;
    }

    bool KeyMovePressed ()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            return true;
        }
        return false;
    }
    int LastKeyMoveUp ()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            lastMoveKeyUp = 1;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            lastMoveKeyUp = 2;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            lastMoveKeyUp = 3;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            lastMoveKeyUp = 4;
        }
        return lastMoveKeyUp;
    }
}
