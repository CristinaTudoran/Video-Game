using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public int MaxHealth;
    protected int CurrentHealth;
    public Slider healthBar;
    public Gradient colour;
    public Image fill;

    // sets the initial health value to maximum.
    void Start()
    {
        CurrentHealth = MaxHealth;
        if (gameObject.tag == "Player" || gameObject.tag == "Boss")
        {
            healthBar.value = MaxHealth;
            fill.color = colour.Evaluate(1f);
        }
        
    }

    // checks if the character has died in which case the user has lost
    // and the script loads the game over scene.
    void Update()
    {
        onDeath();
    }

    public virtual void onDeath()
    {
        Debug.Log("The character died.");
    }

    // Reduces the health of the player when it gets hurt. This method is called
    // from the script HitPlayer to allow the enemies to harm the player.
    // Updates the actual health vale and the the healthh bar.
    public void damage(int damageToGet)
    {
        CurrentHealth -= damageToGet; 
        if (gameObject.tag == "Player" || gameObject.tag == "Boss")
        {
            healthBar.value = CurrentHealth;
            fill.color = colour.Evaluate(healthBar.normalizedValue);
        }
    }
}
