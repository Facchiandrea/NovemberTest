using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float movementSpeed = 2f;
    float speedLimiter = 0.5f;
    float horizontalMovement = 0f;
    float verticalMovement = 0f;
    private SpriteRenderer spriteRenderer;
    private bool movementInputPressed;
    public bool diagonalMovement;
    private float initialMSpeed;
    public bool speedReduced;



    private void Awake()
    {
        initialMSpeed = movementSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (diagonalMovement && speedReduced == false)
        {
            movementSpeed = movementSpeed * speedLimiter;
            speedReduced = true;
        }
        else
        {
            speedReduced = false;
            movementSpeed = initialMSpeed;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
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

        //horizontalMovement = Input.GetAxis("Horizontal");
        //verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.up * Time.fixedDeltaTime * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Vector3.right * Time.fixedDeltaTime * movementSpeed);
            spriteRenderer.flipX = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime * movementSpeed);
            spriteRenderer.flipX = false;

        }




        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            diagonalMovement = true;
        }
        else
        {
            diagonalMovement = false;

        }

        /*

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
       */

    }

}
