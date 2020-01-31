using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;
    

    private Rigidbody2D rb;
    private Vector2 moveVelocity;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal")*speedX, Input.GetAxisRaw("Vertical")*speedY);
        moveVelocity = moveInput;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

}
