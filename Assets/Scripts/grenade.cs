using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attcahed to the grenade prefab and handles the behaviour of the grenade.
// It also uses the method hurtEnemy() from the scripts HealthManager and BossHealthManager.
public class grenade : MonoBehaviour
{
    public GameObject explosionEffect;
    public Vector2 startSpeed;
    public float dalayExplodeTime;
    public float destroyBombTime;
    public float radius; // circle radius in which the grenade has impact.
    public int power; // units of health reduced from an object with health manager when is in the grenade's range of impact.
    private Rigidbody2D rb2d;

    // Moves the genade.
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * startSpeed.x + transform.up * startSpeed.y;

        Invoke("Explode", dalayExplodeTime);
    }

    void Explode()
    {
        Invoke("DestoryThisBomb", destroyBombTime);
    }

    // Destroys the bomb and harms nearby enemies or the boss. This is done by creating an array of clliders
    // with in a specified radius by using the  bult-in method OverlapCirceAll.
    // To apply the impact of the granade the method hurtEnemy is called  from the scripts EnemyHealthManager and BossHealthManager
    // After it destroys the grenade, it instantiates an explosion effect and plays the relevant sound effect.
    void DestoryThisBomb()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius); //Array of nearby colliders
        Destroy(gameObject);

        foreach (Collider2D nearbyObject in colliders)
        {
            EnemyHealthManager enemy = nearbyObject.GetComponent<EnemyHealthManager>();
            BossHealthManager boss = nearbyObject.GetComponent<BossHealthManager>();

            if (enemy != null) // it checks if an object exists nearby to avoid null reference exceptions.
            {           
                enemy.hurtEnemy(power);
            }
            else if(boss != null)
            {
                boss.hurtEnemy(power/3);
            }
        }

        Instantiate(explosionEffect, transform.position, transform.rotation);
        SoundManagerScript.PlaySound("grenadeSound");
    }
}
