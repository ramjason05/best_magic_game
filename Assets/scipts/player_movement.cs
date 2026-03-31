using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 100; // health bar 
    public float moveSpeed = 8f; // Movement
    public float jumpForce = 10f; // physics behind jump
    private Rigidbod2D rb; // unity's data type, 2D component that adds physics

    private bool isGrounded; // automatically set to True 

    void Start()
    {
        rb = GetComponent<RigidBod2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.Getaxis("Horizontal"); // get horizontal input ( -1 = left / 1 = right)

        //Apply horizontal movement,  while keeping same y-velocity
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //If player jumps if grounded
        if ( Input.GetButton("Jump") && isGrounded )
        {
            rb.Velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

    }
    void onCollisionEnter2D(CollectionExte)
}
