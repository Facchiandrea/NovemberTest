using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float movementSpeed = 2f;
    float speedLimiter = 0.75f;
    float horizontalMovement = 0f;
    float verticalMovement = 0f;
    private SpriteRenderer spriteRenderer;
    private bool movementInputPressed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            movementInputPressed = true;
            animator.SetBool("isMoving", true);
        }
        else
        {
            movementInputPressed = false;
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        if (horizontalMovement != 0 && verticalMovement != 0)
        {
            horizontalMovement *= speedLimiter;
            verticalMovement *= speedLimiter;
        }


        rb.velocity = new Vector2(horizontalMovement * movementSpeed, verticalMovement * movementSpeed);

        if (movementInputPressed == false)
        {
            rb.velocity = new Vector2(0, 0);

        }


        if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
        }


    }
}
