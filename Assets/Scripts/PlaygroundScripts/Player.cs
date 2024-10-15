using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    // Extra Jump
    public int maxJumpValue;
    private int maxjump;

    // Sound management
    private bool wasGrounded; 

    private void Start()
    {
        maxjump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
        wasGrounded = true; // Initialize as grounded
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);

        // Jump logic
        if (Input.GetMouseButtonDown(0) && maxjump > 0)
        {
            maxjump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && maxjump == 0 && isGrounded)
        {
            Jump();
        }

      
        if (isGrounded)
        {
            maxjump = maxJumpValue;
        }

        // Handle landing sound
        if (isGrounded && !wasGrounded) 
        {
            AudioManager.instance.Play("Land");
        }

        wasGrounded = isGrounded; 
    }

    void Jump()
    {
        AudioManager.instance.Play("Jump");
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, JumpSpeed));
    }
}
