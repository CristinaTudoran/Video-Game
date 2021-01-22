using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the health game object and allows the player to collect health.
// It also sends information to the script Health Manager. 
public class CollectHealth : MonoBehaviour
{
    public int healthAvailable;

    // When the collider of the player and the collider of the health object collide it
    // allows the player to collect the available health.
    // It calls addHealth() from the script HealthManager to update the current amount of health and the health bar.

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            col.gameObject.GetComponent<PlayerHealthManager>().addHealth(healthAvailable);
            Destroy(gameObject);
        }

    }

}
