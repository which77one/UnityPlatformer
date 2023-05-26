using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;

    protected Collider2D col;
    public Animator animator;
    

    //Walk
    private float x_axis;
    public float movementSpeed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
<<<<<<< Updated upstream
    [SerializeField] protected float distanceToCollider = .02f;
    //The layers the player should check and see for movement restrictions
    [SerializeField] protected LayerMask collisionLayer;
    private float horizontalInput;


    //Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 10f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    void Start()
    {

=======
    void Start()
    {
        animator = GetComponent<Animator>();
>>>>>>> Stashed changes
    }
    void Update()
    {
       if  (Input.GetAxisRaw("Horizontal") != 0)
        {
        x_axis = Input.GetAxisRaw("Horizontal");
        }
       else
        {
            x_axis = 0;
        }
        if (isDashing)
        {
            return;
        }
        animator.SetFloat("Speed", Mathf.Abs(x_axis));
        Jump();
        Flip();
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
       
        
        
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(x_axis * movementSpeed , rb.velocity.y);
        SpeedModifier();

    }
    protected virtual bool CollisionCheck(Vector2 direction, float distance, LayerMask collision)
    {
        //Sets up an array of hits so if the player is colliding with multiple objects, it can sort through each one to look for one it should
        RaycastHit2D[] hits = new RaycastHit2D[10];
        //An int to help sort the hits variable so the Character can run a for loop and check the values of each collision
        int numHits = col.Cast(direction, hits, distance);
        //For loop that sorts hits with the int value it receives based on the Collider2D.Cast() method
        for (int i = 0; i < numHits; i++)
        {
            if ((1 << hits[i].collider.gameObject.layer & collision) != 0)
            {  
                return true;
            }
        }
        return false;
    }
    private void SpeedModifier()
    {
        //Long if statement that checks to see if character is jumping or falling and running into a wall
        if((rb.velocity.x > 0 && CollisionCheck(Vector2.right, distanceToCollider, collisionLayer)) || (rb.velocity.x < 0 && CollisionCheck(Vector2.left, distanceToCollider, collisionLayer)) && IsGrounded())
        {
            //Sets a very small horizontal velocity value so the player can naturally fall if touching a wall while jumping
            rb.velocity = new Vector2(.01f, rb.velocity.y);
        }
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
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    
    
    
}

