using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;

    [SerializeField] private Rocket rocket;

    private bool isAbleToPickItem = false;
    private Item itemNearPlayer;
    private TypeItem typePickedItem;

    private bool isAbleToPutItem = false;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal") * speedX, Input.GetAxisRaw("Vertical") * speedY);
        moveVelocity = moveInput;

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
}
