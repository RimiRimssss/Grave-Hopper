using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed; //For movement
    public float jumpingPower; //For Jump
    public float horizontal;

    public bool isGrounded; //For Jump
    public bool isFacingRight; //For Flip

    private Animator animator;
    public bool isWalking; //walk animation
    public bool isJumping; //jump animation

    public Transform groundCheck; //For Jump
    public LayerMask groundLayer; //For Jump

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();
        HandleAnimationWalk();
        HandleAnimationJump();
        Flip();
    }

    void PlayerMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.Log("Horizontal Value: " + horizontal);
        if (Input.GetButtonDown("Jump") && IsGrounded()) //If Button Hit and is player grounded
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); //Jump
            isJumping = true;
        }
        if (IsGrounded() && rb.velocity.y == 0)
        {
            isJumping = false;
        }
        isWalking = horizontal != 0 ? true : false;
    }

    void HandleAnimationWalk()
    {
        animator.SetBool("isWalking", isWalking);
    }

    void HandleAnimationJump()
    {
        animator.SetBool("isJumping", isJumping);
    }

    void Flip()
    {
        if (isFacingRight && horizontal > 0f ||  !isFacingRight &&  horizontal < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //Movement left and right

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void LateUpdate()
    {
        
    }

}
