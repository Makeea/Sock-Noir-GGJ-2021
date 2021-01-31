using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator animator;
    private BoxCollider2D collider2D;
    private AudioSource footStep;

    private Vector2 standingPosition;
    private Vector2 crouchingPosition;
    private int originalExtraJumpCount;

    // State Machine
    private enum State { idle = 0, running = 1, jumping = 2, falling = 3, hurt = 4, crouch = 5, crawl = 6 }
    private State state = State.idle;

    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int extraJumpCount = 1;
    [SerializeField] private ParticleSystem dust;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
        footStep = GetComponent<AudioSource>();

        standingPosition = collider2D.size;
        crouchingPosition = new Vector2(standingPosition.x, standingPosition.y / 2);
        originalExtraJumpCount = extraJumpCount;
    }

    // Update is called once per frame
    private void Update()
    {
        if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        animator.SetInteger("state", (int)state); // sets animation based on enumerator state
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"trigger entered {collision.tag}");
        // TODO: probably move clue case (with PickupClue(...)) into class Clue's Update method
        switch (collision.tag.ToLower())
        {
            case "clue":
                PickupClue(collision);
                break;
            default:
                Debug.LogWarning($"Unknown Tag collided collision.tag");
                break;
        }

        collision.gameObject.SendMessage("SetInteract", true);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        collider.gameObject.SendMessage("SetInteract", false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Collision with {other.gameObject.tag}");
        switch (other.gameObject.tag.ToLower())
        {
            case "wall":
                HitWall();
                break;
            case "checkpoint":
                // Handle Checkpoint
                break;
            default:
                //Debug.LogWarning($"Unknown Tag collided {other.gameObject.tag}");
                break;
        }
    }

    private void Movement()
    {
        var hDirection = Input.GetAxis("Horizontal");
        var vDirection = Input.GetAxis("Vertical");
        var isCrouching = vDirection < 0;


        var xVelocity = speed;
        //Holding Down
        if (isCrouching)
        {
            xVelocity = xVelocity / 2;
            collider2D.size = crouchingPosition;
            transform.localScale = new Vector2(transform.localScale.x, 0.5f);
        }
        else
        {
            collider2D.size = standingPosition;
            transform.localScale = new Vector2(transform.localScale.x, 1);
        }

        // Moving Left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-xVelocity, rb.velocity.y);
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        // Moving Right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(xVelocity, rb.velocity.y);
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        if (collider2D.IsTouchingLayers(ground))
        {
            extraJumpCount = originalExtraJumpCount;
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && extraJumpCount > 0 && !isCrouching)
        {
            Jump();
            extraJumpCount--;
        }

        //Action
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log($"Pressing {Input.g}")
        }
    }

    private void HitWall()
    {
        state = State.idle;
    }

    private void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (collider2D.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void PickupClue(Collider2D collision)
    {
        // Only pick up if button pressed
        if (Input.GetButtonDown("Fire1")) // Ctrl Left
        {
            Debug.Log($"Picked up {collision.tag}");
            Destroy(collision.gameObject);
        }
    }

    private void PlaySoundFootStep()
    {
        footStep.Play();
    }

    private void CreateDust()
    {
        dust.Play();
    }
}
