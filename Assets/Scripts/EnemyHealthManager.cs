using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the health of the enemies.
public class EnemyHealthManager : HealthManager
{ 
    public GameObject alienDrop;

    // checks if the enemy has died in which case it instantiates an alien drop (health object).
    public override void onDeath()
    {
        base.onDeath();
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(alienDrop, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("alienDeathSound");
        }
    }

}
