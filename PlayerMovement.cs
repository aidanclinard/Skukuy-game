using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4f;

    public Rigidbody2D rb;

    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey("left shift"))
        {
            moveSpeed = 2f;
        }
        else
        {
            moveSpeed = 4f;
        }
    }

    void FixedUpdate()
    {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
