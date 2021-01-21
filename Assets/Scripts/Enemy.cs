
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to every enemy object and allows the enemies to follow the player when he is inside a specific range.
public class Enemy : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float chaseRange;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Gets the position of the player and call the mthod chase when he is in the specified range so that the enemies
    // follow him. It stops the enemies form following the player otherwise. 
    void Update()
    {
        GameObject player2 = GameObject.FindGameObjectWithTag("Player");

        if (player2!=null)
        {
            player = player2.GetComponent<Transform>();
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < chaseRange)
            {
                chase();
            }
            else if (distanceToPlayer > chaseRange)
            {
                stopChasing();
            }
        }
    }

    // Specifies the direction and speed at which the enemies move depending on the position of the player.
    void chase() { 
    
        if ((transform.position.x < player.position.x) && (transform.position.y == player.position.y))
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else if ((transform.position.x < player.position.x) && (transform.position.y > player.position.y))
        {
            rb.velocity = new Vector2(moveSpeed, -moveSpeed);
        }
        else if ((transform.position.x < player.position.x && transform.position.y < player.position.y))
        {
            rb.velocity = new Vector2(moveSpeed, moveSpeed);
        }
        else if ((transform.position.x > player.position.x) && (transform.position.y == player.position.y))
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        else if ((transform.position.x > player.position.x) && (transform.position.y > player.position.y))
        {
            rb.velocity = new Vector2(-moveSpeed, -moveSpeed);
        }
        else if ((transform.position.x > player.position.x) && (transform.position.y < player.position.y))
        {
            rb.velocity = new Vector2(-moveSpeed, moveSpeed);
        }
        else if ((transform.position.x == player.position.x && transform.position.y < player.position.y))
        {
            rb.velocity = new Vector2(0, moveSpeed);
        }
        else if ((transform.position.x == player.position.x) && (transform.position.y > player.position.y))
        { 
            rb.velocity = new Vector2(0, -moveSpeed);
        }
        else if ((transform.position.x == player.position.x) && (transform.position.y == player.position.y))
        { 
            rb.velocity = new Vector2(0, 0);
        }
    }

    // Stop following the player
    void stopChasing()
    {
        rb.velocity = new Vector2(0, 0);
    }
   
}
