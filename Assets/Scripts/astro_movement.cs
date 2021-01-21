
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for the player's movement, walking and running.
public class astro_movement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer flip;
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float currentSpeed=0f;
    bool lookright = true;

    public Rigidbody2D rb;

    Vector2 movement;

    // It gets the direction at which the player should move from the user.
    // It sets the Speed parameter used for the movement animations (i.e to distinguish between "Idle" and "walking").
    // It flips the player so that he faces to the right direction when moving.

    void Update()
    {
        float speedx = Input.GetAxis("Horizontal") * setCurrentSpeed();
        float speedy = Input.GetAxis("Vertical") * setCurrentSpeed();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // "Speed" -> Speed in animation properties.
        //  speed -> speed variable

        animator.SetFloat("Horizontal", movement.x);

        animator.SetFloat("Vertical", movement.y);

        animator.SetFloat("Speed", movement.sqrMagnitude); //square magnitude was used to get a positive value even when the player moves to the left.

        if (speedx > 0 && lookright == false || speedx < 0 && lookright == true)
        {
            flip.flipX = !flip.flipX; // player face to the right direction while moving.
            lookright = !lookright;
        }

    }

    // Moves the player to the specified position.
    // FixedUpdate() is called a fixed number of times per second.
    // Time.fixedDeltaTime was used to ensure that the player's speed is the same in any platform. 
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * setCurrentSpeed() * Time.fixedDeltaTime);
    }

    // Sets the speed of the movement.
    // If the user holds the shift button the player moves at maximum speed.
    float setCurrentSpeed()
    {

        if (Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift))
         {
            currentSpeed = runSpeed;
            return currentSpeed;
        }

        else
        {
            currentSpeed = walkSpeed;
            return currentSpeed;
        }
    }
}

