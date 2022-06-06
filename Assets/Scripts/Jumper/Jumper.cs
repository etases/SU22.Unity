using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyJumper : MonoBehaviour
{
    public float walkSpeed ;
    private float moveInput;
    public bool isGrounded;// check if game object is touching the platform
    private Rigidbody2D rb;



    public bool canJump;
    public float jumpValue = 0.0f;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");


        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }


        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += 0.1f;
        }

        if(Input.GetKeyDown("space") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (jumpValue >= 10f && isGrounded)
        {
            rb.velocity = new Vector2(0f, jumpValue);
            jumpValue = 0.0f;
            canJump = true;
        }

        if (Input.GetKeyUp("space"))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(0f, jumpValue);
                jumpValue = 0.0f;
            }
            canJump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
        print("enter");
    }
    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
        print("exit");
    }

    void ResetJump()
    {
        canJump = false;
        jumpValue = 0;
    }
    

}

