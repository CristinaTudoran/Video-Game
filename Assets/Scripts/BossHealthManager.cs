using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is attached to the object ALIEN BOSS and manages the health of the final boss and updates the health bar of that character.
public class BossHealthManager : MonoBehaviour
{

    public int bossMaxHealth = 1000;
    public int bossCurrentHealth;
    public Slider healthBar;
    public Gradient colour;
    public Image fill;

    // sets the initial health value to maximum.
    void Start()
    {
        bossCurrentHealth = bossMaxHealth;
        healthBar.value = bossMaxHealth;
        fill.color = colour.Evaluate(1f);
    }

    // checks if the boss has died in which case the user has won the game
    // and the script loads the winning scene.
    void Update()
    {      
        if (bossCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            SoundManagerScript.PlaySound("alienDeathSound");
		    SceneManager.LoadScene("winscreen"); // user has won the game.
        }
    }

    // Reduces the health value when a bullet or grenade hits the boss.
    // Reflects the changes to the health bar as well.
    // This method is called form another script when a bullet or grenade hits the character.
    public void hurtEnemy(int damageToReceive)
    {
        bossCurrentHealth -= damageToReceive;
        healthBar.value = bossCurrentHealth;
        fill.color = colour.Evaluate(healthBar.normalizedValue);
    }

}

