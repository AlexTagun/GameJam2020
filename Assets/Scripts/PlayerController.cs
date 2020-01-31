using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speedX;
    [SerializeField]
    private float speedY;

    private GameObject pickedItem;

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(pickedItem);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("нажмите Е");
            pickedItem = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("Подойдите к объекту");
            pickedItem = null;
        }
    }


}
