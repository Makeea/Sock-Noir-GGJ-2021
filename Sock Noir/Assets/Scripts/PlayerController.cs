using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;    
    private Collider2D collider2D;

    // State Machine
    private enum State { idle = 0, running = 1, jumping = 2, falling = 3, hurt = 4, crouch = 5, crawl = 6 }
    private State state = State.idle;


    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(state != State.hurt)
        {
            Movement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag.ToLower()){
            case "something":
                Something();
                break;
            default:
                Debug.LogWarning($"Unknown Tag collided {collision.tag}");
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Collision with {other.gameObject.tag}");
        switch(other.gameObject.tag.ToLower()){
            case "something":
                // Do somthing?
                break;
            case "checkpoint":
                // Handle Checkpoint
                break;
            default:
                Debug.LogWarning($"Unknown Tag collided {other.gameObject.tag}");
                break;
        }        
    }

    private void Movement(){
        var hDirection = Input.GetAxis("Horizontal");
        var vDirection = Input.GetAxis("Vertical");

        // Moving Left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        // Moving Right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);            
        }        
        //Jumping
        if (Input.GetButtonDown("Jump"))// && collider2D.IsTouchingLayers(ground))
        {
            Jump();   
        }
    }

    private void Something(){
        // TODO: Future event to go here
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }
}
