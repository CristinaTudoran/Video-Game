using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the health of the enemies.
public class EnemyHealthManager : MonoBehaviour
{ 
    public int enemyMaxHealth=1000;
    public int enemyCurrentHealth;
    public GameObject alienDrop;

    // sets the initial health value to maximum.
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
    // checks if the enemy has died in which case it instantiates an alien drop (health object).
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(alienDrop, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound("alienDeathSound");
        }

    }

    // Reduces the health value when a bullet or grenade hits the enemy.
    // This method is called form the scripts Bullet and grenade when a bullet or grenade hits the character.
    public void hurtEnemy(int damageToReceive)
    {
        enemyCurrentHealth -= damageToReceive;
    }
}
