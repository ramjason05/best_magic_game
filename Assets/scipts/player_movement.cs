
using UnityEngine;
using UnityEngine.InputSystem;


public class player_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 100; // health bar 
    public float moveSpeed = 8f; // Movement
    public float jumpForce = 10f; // physics behind jump
    private Rigidbody2D rb; // unity's data type, 2D component that adds physics

    private bool isGrounded; // automatically set to True 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = 0f; // Idle
        if (Keyboard.current.aKey.isPressed  || Keyboard.current.leftArrowKey.isPressed) {
            moveInput = -1f; // Move left from 'a' key or left arrow
        }
        if (Keyboard.current.dKey.isPressed  || Keyboard.current.rightArrowKey.isPressed) {
            moveInput = 1f; // Move right from 'd' key or right arrow
        }

        rb.linearVelocity = new Vector2(moveInput *moveSpeed, rb.linearVelocity.y);

        //Apply horizontal movement,  while keeping same y-velocity
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //If player jumps if grounded
        if ( Keyboard.current.spaceKey.isPressed && isGrounded )
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    }
    
    
