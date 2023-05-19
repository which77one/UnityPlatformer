using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] private Rigidbody2D rb;
     [SerializeField] private Transform groundCheck;
     [SerializeField] private LayerMask groundLayer;
     

    private float x_axis;
    public float movementSpeed= 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    void Update()
    {
        x_axis = Input.GetAxisRaw("Horizontal");

        Jump();

        Flip();
    }

    private void FixedUpdate()
    {
       rb.velocity  = new Vector2(x_axis * movementSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && x_axis <0f || !isFacingRight && x_axis> 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
   private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    //lmao
    
}
