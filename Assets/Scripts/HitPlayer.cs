using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the enemies and allow them to hit the player.
// It sends information to the script HealthManager so that the change
// in the health value of the player is reflected.
 
public class HitPlayer : MonoBehaviour
{
    public int damageAmount = 1;

    // OnCollisioStay instead of OnCollisionEnter so that the enemies are hurting the player
    // as long as they are touching him.
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "player")
        {
            col.gameObject.GetComponent<HealthManager>().damage(damageAmount);
        }

    }

}
