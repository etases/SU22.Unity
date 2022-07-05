using UnityEngine;

public class Jumper : MonoBehaviour
{
    public const float dWalkSpeed = 6;
    public const float dJumpSpeed = 3;

    [Header("Speed Settings")]
    public float walkSpeed = dWalkSpeed;
    public float jumpSpeed = dJumpSpeed;


    [Header("Status")]
    public float moveInput;
    public float jumpValue;
    public float jumpDirection;
    public bool isGrounded;// check if game object is touching the platform

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
        // Check Is Grounded
        if (isGrounded)
        {
            if (rb.velocity.y < -0.05)
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = rb.velocity.y == 0;
        }

        if (!isGrounded)
        {
            jumpValue = 0.0f;
            jumpDirection = 0.0f;
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        var isJump = Input.GetAxisRaw("Jump") != 0;

        // set animation
        setAnim();

        // flip
        spRender.flipX = rb.velocity.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => spRender.flipX
        };

        if (!isGrounded) return;
        if (isJump) // Charge
        {
            jumpDirection = moveInput switch
            {
                > 0 => walkSpeed,
                < 0 => -walkSpeed,
                _ => 0
            };

            if (jumpValue <= 10f)
            {
                jumpValue += 0.1f;
            }
        }
        else
        {
            if (jumpValue != 0) // Jump
            {
                Jump();
            }
            else // Walk
            {
                rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(jumpDirection, jumpValue * jumpSpeed);
        jumpValue = 0.0f;
        jumpDirection = 0.0f;
        isGrounded = false;
    }

    void setAnim()
    {
        anim.SetBool("isRunning", jumpValue == 0 && moveInput != 0 && isGrounded);
        anim.SetBool("isCharge", jumpValue > 0 && isGrounded);
        anim.SetBool("isJumping", !isGrounded && rb.velocity.y > 0);
        anim.SetBool("isFalling", !isGrounded && rb.velocity.y < 0);
    }

}

