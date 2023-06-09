using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    public Flag flag;

    //Walk
    private float x_axis;
    public float movementSpeed = 8f;

    //Jump
    public float jumpingPower = 20f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity = 2f;
    private bool isFacingRight = true;

    //Coyote Time
    private float CoyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump Buffer
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //KnockBackWhenHit
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    
    public bool KnockToRight;
    public bool isSkiing;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("LevelSelection");
        }
        if(KBCounter < 0)
        {
            if(isSkiing == false)
            {
            x_axis = Input.GetAxisRaw("Horizontal");
            }
            
        }
        else 
        {
            if(KnockToRight == true)
            {
                rb.velocity = new Vector2(KBForce , KBForce);
            }
            if(KnockToRight == false)
            {
                rb.velocity = new Vector2(-KBForce , KBForce);
            }
            KBCounter -=Time.deltaTime;
        }
        animator.SetFloat("Speed", Mathf.Abs(x_axis));
        Jump();
        Flip();
        if (IsGrounded())
        {
            coyoteTimeCounter = CoyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        } 
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Flag")
        {
            animator.SetTrigger("Winning");
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Flag")
        {
            animator.SetTrigger("notWinning");
        }
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(x_axis * movementSpeed , rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && x_axis < 0f || !isFacingRight && x_axis > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void Jump()
    {
        if (jumpBufferCounter >0f  && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x * jumpVelocity, jumpingPower);
            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else 
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        
    }
    

    
    
    
    
}

