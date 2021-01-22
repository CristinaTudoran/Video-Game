using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is attached to the plaier. It manages its health nad updates the health bar.
public class PlayerHealthManager : HealthManager
{
    private int healthUntilFull;

    public override void onDeath()
    {
        base.onDeath();
        if (CurrentHealth <= 0)
        {

            Destroy(gameObject);
            SoundManagerScript.PlaySound("playerDeathSound");
            SceneManager.LoadScene("gameoverbutton1");
        }
    }

    // Adds an amount of health to the current health value and updates the health bar accordingly.
    // Guards against exceeding the max health value.
    // This method is called from the script CollectHealth to allow the player collect health
    // and the corresponding value to be updated and reflected to the health bar.
    public void addHealth(int healthToAdd)
    {
        healthUntilFull = MaxHealth - CurrentHealth;

        if (healthUntilFull > healthToAdd)
        {
            CurrentHealth += healthToAdd;
            healthBar.value = CurrentHealth;
            fill.color = colour.Evaluate(healthBar.normalizedValue);
        }

        else
        {
            CurrentHealth = MaxHealth;
            healthBar.value = CurrentHealth;
            fill.color = colour.Evaluate(healthBar.normalizedValue);
        }
    }

}
