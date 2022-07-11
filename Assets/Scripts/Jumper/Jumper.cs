using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumper : MonoBehaviour
{
    public const float dWalkSpeed = 6;
    public const float dJumpSpeed = 3;
    public const float dJumpCharge = 0.05f;
    public const float dJumpChargeMax = 10f;
    private static bool _shouldLoadPlayerValue;

    [Header("Speed Settings")] public float walkSpeed = dWalkSpeed;

    public float jumpSpeed = dJumpSpeed;
    public float jumpCharge = dJumpCharge;
    public float jumpChargeMax = dJumpChargeMax;

    [Header("Status")] public float moveInput;

    public float jumpValue;
    public float jumpDirection;
    public bool isGrounded; // check if game object is touching the platform

    [Header("Serialize")] [SerializeField] public PhysicsMaterial2D normalMat; //value = 0

    public PhysicsMaterial2D bouncyMat; //value = 0.7
    private Animator anim;

    private Rigidbody2D rb;
    private SpriteRenderer spRender;
    private Storage storage;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spRender = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        storage = FindObjectOfType<Storage>();
        if (storage == null) throw new Exception("Storage not found");

        if (!storage.data.hasPlayerSaved) return;
        transform.position = storage.data.location;
        rb.velocity = storage.data.velocity;
        isGrounded = storage.data.isGrounded;
        jumpSpeed = storage.data.jumpSpeed;
        walkSpeed = storage.data.walkSpeed;
    }

    private void Update()
    {
        if (storage != null)
        {
            if (_shouldLoadPlayerValue)
            {
                if (storage.data.hasPlayerSaved)
                {
                    transform.position = storage.data.location;
                    rb.velocity = storage.data.velocity;
                    isGrounded = storage.data.isGrounded;
                    jumpSpeed = storage.data.jumpSpeed;
                    walkSpeed = storage.data.walkSpeed;
                    Debug.Log("Loaded data value");
                }

                _shouldLoadPlayerValue = false;
            }
            else
            {
                storage.data.hasPlayerSaved = true;
                storage.data.location = transform.position;
                storage.data.velocity = rb.velocity;
                storage.data.isGrounded = isGrounded;
                storage.data.jumpSpeed = jumpSpeed;
                storage.data.walkSpeed = walkSpeed;
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            _shouldLoadPlayerValue = true;
            PauseMenu.gameIsPaused = true;
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Single);
            return;
        }

        // Check Is Grounded
        if (isGrounded)
        {
            if (rb.velocity.y < -0.05) isGrounded = false;
        }
        else
        {
            isGrounded = rb.velocity.y == 0;
            // change material
            rb.sharedMaterial = rb.velocity.y > 0 ? bouncyMat : normalMat;

            // Event
            if (isGrounded)
                SimpleEventManager.TriggerEvent("GroundEvent", new EventData
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

        // Short key Q & E
        if (Input.GetKey(KeyCode.Q))
        {
            isJump = true;
            moveInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            isJump = true;
            moveInput = 1;
        }

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
                if (moveInput != 0)
                    SimpleEventManager.TriggerEvent("WalkEvent", new EventData
                    {
                        {"jumper", this}
                    });
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
            SimpleEventManager.TriggerEvent("HitWallEvent", new EventData
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
        SimpleEventManager.TriggerEvent("JumpEvent", new EventData
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