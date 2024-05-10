using UnityEngine;

public class movementplayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool Grounded;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded
        Grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        
        // Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip character if moving in opposite direction
        if (moveInput > 0 && !isFacingRight || moveInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }

        // Apply animations
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("Grounded", Grounded);
        
    }

    private void Update()
    {
        // Jumping
        if (Grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
