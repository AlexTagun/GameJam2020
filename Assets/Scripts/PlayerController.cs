using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;
    [SerializeField] private Transform _visual;


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
}
