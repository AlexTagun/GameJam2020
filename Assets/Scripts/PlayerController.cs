using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;
    [SerializeField] private Rocket rocket;
    [SerializeField] private Transform _visual;
    [SerializeField] private Animator playerAnimator;

    private bool isAbleToPickItem = false;
    private Item itemNearPlayer;
    private TypeItem typePickedItem;

    private bool isAbleToPutItem = false;
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
        Debug.Log(_isGrounded);
        if(!_isGrounded) return;

        Vector2 vectorAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerAnimator.SetFloat("Horizontal", vectorAxis.x);
        playerAnimator.SetFloat("Vertical", vectorAxis.y);
        playerAnimator.SetFloat("Magnitude", vectorAxis.magnitude);

        if (Input.GetKeyDown(KeyCode.E)) {
            if (isAbleToPickItem) {
                typePickedItem = itemNearPlayer.typeItem;
                itemNearPlayer.PickItem(itemNearPlayer);
                isAbleToPickItem = false;
            }

            if (isAbleToPutItem) {
                rocket.PutItem(typePickedItem);
                isAbleToPutItem = false;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Item") {
            Debug.Log("нажмите Е, чтобы подобрать");
            isAbleToPickItem = true;
            itemNearPlayer = collision.gameObject.GetComponent<Item>();
        }

        if (collision.gameObject.tag == "Rocket") {
            Debug.Log("Нажмите E, чтобы сдать");
            isAbleToPutItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Item") {
            Debug.Log("Подойдите к объекту");
            isAbleToPickItem = false;
        }

        if (collision.gameObject.tag == "Rocket") {
            Debug.Log("Подойдите к объекту");
            isAbleToPutItem = false;
        }
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
}
