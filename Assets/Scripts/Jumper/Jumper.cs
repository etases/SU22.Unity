using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    [Header("Speed Settings")]
    public float walkSpeed;
    public float jumpSpeed;


    [Header("Status")]
    private float moveInput;
    public bool isGrounded;// check if game object is touching the platform
    public float jumpValue = 0.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        //walk
        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }
        

        //charge jump 
        if ( (Input.GetKey("space") || (Input.GetKey("e") ) || (Input.GetKey("q")) ) && isGrounded)
        {
            if (jumpValue <= 10f) {
                jumpValue += 0.1f;
            }        
        }

        //jump up
        if (Input.GetKeyUp("space"))
        {
            if (isGrounded)
            {
                Jump();
            }

        }
        //jump right
        else if (Input.GetKeyUp("e"))
        {
            if (isGrounded)
            {
                JumpRight();
            }

        }
        //jump left
        else if (Input.GetKeyUp("q"))
        {
            if (isGrounded)
            {
                JumpLeft();
            }

        }




    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        jumpValue = 0f;
        print("enter");
    }
    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
        print("exit");
    }

    void resetJump() { 
        jumpValue = 0.0f;
    }

    void Jump()
    {
        rb.velocity = new Vector2(0f, jumpValue * jumpSpeed);;
    }
    void JumpLeft()
    {
        rb.velocity = new Vector2(-walkSpeed, jumpValue * jumpSpeed);
    }
    void JumpRight()
    {
        rb.velocity = new Vector2(walkSpeed, jumpValue * jumpSpeed);
    }

}

