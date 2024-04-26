
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask whatIsGround;
    public Animator animator;
    public int Collections = 0;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        //verfica se o personagen está no chao
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //movimento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        Vector2 moveDirection = new Vector2(moveInput, 0);

        if(moveDirection.magnitude > 0.1)
        {
            if(moveInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);                

            }
            else if(moveInput < 0)
            {             
                transform.localScale = new Vector3(-1, 1, 1);               
            }
        }

        //animacao do pulo
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        //
        {
            animator.SetBool("Jump", true);
        }
        if (isGrounded && rb.velocity.y == 0)
        {
            animator.SetBool("Jump", false);
        }
    }
}
