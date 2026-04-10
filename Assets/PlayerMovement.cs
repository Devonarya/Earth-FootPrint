using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private bool isRunning;
    private float currentSpeed;
    public SpriteRenderer SpriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input
        float input = Input.GetAxisRaw("Horizontal");

        // Check if running (Left Shift key)
        isRunning = Input.GetKey(KeyCode.LeftShift) && input != 0;

        // Set current speed based on running state
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // Create movement vector
        movement = new Vector2(input, 0f);

        // Update animator parameters
        if (input != 0)
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", isRunning);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("takePicture");
        }


        // Handle character facing direction
        if (input < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else if (input > 0) 
        {
            SpriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {
        // Move the character using current speed
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}
