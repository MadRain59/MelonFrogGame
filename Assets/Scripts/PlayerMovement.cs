using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    // int = wholeNumber, float = decimalNumber, script = text, bool = true/false
    //if variable is only needed in one part of the script, then only post it in that part, but if it needs to be used elswhere, put variable at the very top.
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    float moveLeftRight;
    [SerializeField] float moveSpeed =5;
    [SerializeField] float JumpForce =12;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    public void Update()
    {
            moveLeftRight = Input.GetAxisRaw("Horizontal");

            //Horizontal axis is multiplied by x velocity, eg. if x velocity is -0.5 then moveLeftRight will have a value of -3.5 and move left  
            rb.velocity = new Vector2(moveLeftRight * moveSpeed, rb.velocity.y);

        //This is the long way of writing Horizontal movement
        //Value of <0 means move left, value of >0 means move right.
        //if (moveLeftRight > 0)
        //{
        //rb.velocity = new Vector2(5, 0);
        //}
        //if (moveLeftRight < 0)
        //{
        //rb.velocity = new Vector2(-5, 0);
        //}

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            jumpSoundEffect.Play();
        }

        UpdateAnimationStates();


    }

    private void UpdateAnimationStates()
    {
        MovementState state;
        if (moveLeftRight > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (moveLeftRight < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
        //anim.SetBool requires String arguement, and bool value(meaning true/false)
        //for player animations need 3 lines
        //1st for >0 for player to run right, 2nd for <0 for player to run left, 3rd for ==0 for player to return to idle
        //shorter way to write is if (moveLeftRight != 0) { anim.SetBool("running", true);}

        //if (moveLeftRight > 0)
        //{
        //sprite.flipX = false; because player is moving right and you don't want it to flip
        //anim.SetBool("running", true);
        //sprite.flipX = false;
        //}

        //else if (moveLeftRight < 0)
        //{
        //sprite.flipX = true; because player is moving left and you want it to flip
        //anim.SetBool("running", true);
        //sprite.flipX = true;
        //}

        //else if (moveLeftRight == 0) this is long way to write it
        //else
        //{
        //anim.SetBool("running", false);
        //}

        //for jumping you need to call on the velocity of "y" using rb.velocity.y,  
        //it is always more than 0 so you need to put a value o 0.1 and for falling its -0.1
        //if (rb.velocity.y > 0.1)
        //{
        //anim.SetBool("jumping", true);
        //}
        //else
        //{
        //anim.SetBool("jumping", false);
        //}

        //if (rb.velocity.y < -0.1)
        //{
        //anim.SetBool("falling", true);
        //} 
        //else
        //{
        //anim.SetBool("falling", false);
        //}
        //all of this is the bool method of applying animations and calling from animator
    }
    private bool IsGrounded()
    {
            //BoxCast creates a box around the player to detect whether or not object is touching ground.
            //BoxCast needs origin, size, angle, direction, distance, layermask
            //still very confusing honestly.
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);
    }

    
}
