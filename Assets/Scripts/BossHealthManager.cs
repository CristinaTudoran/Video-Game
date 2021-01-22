using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is attached to the object ALIEN BOSS and manages the health of the final boss and updates the health bar of that character.
public class BossHealthManager : HealthManager
{

    // checks if the boss has died in which case the user has won the game
    // and the script loads the winning scene.
    public override void onDeath()
    {
        base.onDeath();
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            SoundManagerScript.PlaySound("alienDeathSound");
		    SceneManager.LoadScene("winscreen"); // user has won the game.
        }
    }

}

