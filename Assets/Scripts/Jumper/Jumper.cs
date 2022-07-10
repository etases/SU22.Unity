using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public const float dWalkSpeed = 6;
    public const float dJumpSpeed = 3;
    public const float dJumpCharge = 0.05f;
    public const float dJumpChargeMax = 10f;

    [Header("Speed Settings")] public float walkSpeed = dWalkSpeed;

    public float jumpSpeed = dJumpSpeed;
    public float jumpCharge = dJumpCharge;
    public float jumpChargeMax = dJumpChargeMax;

    [Header("Status")] public float moveInput;

    public float jumpValue;
    public float jumpDirection;
    public bool isGrounded; // check if game object is touching the platform
    private Animator anim;

    private Rigidbody2D rb;
    private SpriteRenderer spRender;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spRender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // Check Is Grounded
        if (isGrounded)
        {
            if (rb.velocity.y < -0.05) isGrounded = false;
        }
        else
        {
            isGrounded = rb.velocity.y == 0;
            if (isGrounded)
                SimpleEventManager.TriggerEvent("GroundEvent", new Dictionary<string, object>
                {
                    {"jumper", this}
                });
        }

        if (!isGrounded)
        {
            jumpValue = 0.0f;
            jumpDirection = 0.0f;
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        var isJump = Input.GetAxisRaw("Jump") != 0;

        // set animation
        SetAnim();

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

            if (jumpValue <= jumpChargeMax) jumpValue += jumpCharge;
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
                SimpleEventManager.TriggerEvent("WalkEvent", new Dictionary<string, object>
                {
                    {"jumper", this}
                });
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
            SimpleEventManager.TriggerEvent("HitWallEvent", new Dictionary<string, object>
            {
                {"jumper", this},
                {"wall", col.gameObject}
            });
    }

    private void Jump()
    {
        rb.velocity = new Vector2(jumpDirection, jumpValue * jumpSpeed);
        jumpValue = 0.0f;
        jumpDirection = 0.0f;
        isGrounded = false;
        SimpleEventManager.TriggerEvent("JumpEvent", new Dictionary<string, object>
        {
            {"jumper", this}
        });
    }

    private void SetAnim()
    {
        anim.SetBool("isRunning", jumpValue == 0 && moveInput != 0 && isGrounded);
        anim.SetBool("isCharge", jumpValue > 0 && isGrounded);
        anim.SetBool("isJumping", !isGrounded && rb.velocity.y > 0);
        anim.SetBool("isFalling", !isGrounded && rb.velocity.y < 0);
    }
}