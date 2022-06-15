using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public const float dWalkSpeed = 6;
    public const float dJumpSpeed = 3;

    [Header("Speed Settings")]
    public float walkSpeed = dWalkSpeed;
    public float jumpSpeed = dJumpSpeed;


    [Header("Status")]
    private float moveInput;
    public float jumpValue = 0.0f;
    public bool isGrounded;// check if game object is touching the platform
    public float posY;

    private Rigidbody2D rb;
    private SpriteRenderer spRender;
    private Animator anim;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spRender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
       
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        //set animation
        setAnim();

        //flip
        if (rb.velocity.x < 0)
            spRender.flipX = true;
        else if (rb.velocity.x > 0)
            spRender.flipX = false;

        //walk
        if (jumpValue == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
        }



        //charge jump 
        if ((Input.GetKey("space") || (Input.GetKey("e")) || (Input.GetKey("q"))) && isGrounded)
        {
            if (jumpValue <= 10f)
            {
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

    void resetJump()
    {
        jumpValue = 0.0f;
    }

    void Jump()
    {
        rb.velocity = new Vector2(0f, jumpValue * jumpSpeed);
    }
    void JumpLeft()
    {
        rb.velocity = new Vector2(-walkSpeed, jumpValue * jumpSpeed);
    }
    void JumpRight()
    {
        rb.velocity = new Vector2(walkSpeed, jumpValue * jumpSpeed);
    }

    void setAnim()
    {
        //run
        if (moveInput != 0 && isGrounded == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //charge
        if (jumpValue > 0 && isGrounded == true)
        {
            anim.SetBool("isCharge", true);
        }
        else if (jumpValue > 0 && isGrounded == false)
        {
            anim.SetBool("isCharge", false);
        }

        //jump
        if(rb.velocity.y>0)
        {
            anim.SetBool("isJumping", true);
        }
        else if(rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
    }

}

