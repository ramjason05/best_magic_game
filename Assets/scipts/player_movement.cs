
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

    public bool IsMoving { get; private set; } // Property to track if the player is moving

    private Vector2 moveInput; //2D vector storing input , x/ y axis

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
          //Apply horizontal movement,  while keeping same y-velocity
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        //Jumping Function
        if ( Keyboard.current.spaceKey.isPressed && isGrounded )
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
      
    }
    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving =  moveInput != Vector2.zero;
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
    
    
