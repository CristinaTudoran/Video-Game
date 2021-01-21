using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is attached to the plaier. It manages its health nad updates the health bar.
public class HealthManager : MonoBehaviour
{

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public Slider healthBar;
    public Gradient colour;
    public Image fill;
    public int healthUntilFull;

    // sets the initial health value to maximum.
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthBar.value = playerMaxHealth;
        fill.color = colour.Evaluate(1f);

    }
    // checks if the player has died in which case the user has lost
    // and the script loads the game over scene.
    void Update()
    {
        if (playerCurrentHealth <= 0){

            Destroy(gameObject);
            SoundManagerScript.PlaySound("playerDeathSound");
		    SceneManager.LoadScene("gameoverbutton1");
        } 
    }

    // Reduces the health of the player when it gets hurt. This method is called
    // from the script HitPlayer to allow the enemies to harm the player.
    // Updates the actual health vale and the the healthh bar.
    public void hurtPlayer(int damageToGive)
    {
       playerCurrentHealth -= damageToGive;
       healthBar.value = playerCurrentHealth;
       fill.color = colour.Evaluate(healthBar.normalizedValue);
    }

    // Adds an amount of health to the current health value and updates the health bar accordingly.
    // Guards against exceeding the max health value.
    // This method is called from the script CollectHealth to allow the player collect health
    // and the corresponding value to be updated and reflected to the health bar.
    public void addHealth(int healthToAdd)
    {
        healthUntilFull = playerMaxHealth - playerCurrentHealth;

        if (healthUntilFull > healthToAdd)
        {
            playerCurrentHealth += healthToAdd;
            healthBar.value = playerCurrentHealth;
            fill.color = colour.Evaluate(healthBar.normalizedValue);

        }

        else
        {
            playerCurrentHealth = playerMaxHealth;
            healthBar.value = playerCurrentHealth;
            fill.color = colour.Evaluate(healthBar.normalizedValue);
        }
    }

}
