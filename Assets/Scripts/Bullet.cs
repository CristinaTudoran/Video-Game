using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attcahed to the bullet prefab and handles the behaviour of the bullet.
// It also uses the method hurtEnemy() from the scripts HealthManager and BossHealthManager.
public class Bullet : MonoBehaviour
{   
    
    public float speed;
    public int damage;
    public float destroyDistance;
    public GameObject bulletEffect;


    private Rigidbody2D rb2d;
    private Vector3 startPos;


    void Start()
    {   // Moves the bullet.
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
        startPos = transform.position;

    }

    void Update()
    {   // Destroys the bullet after covering some distance to ensure that it does not travel for ever in case it does not hit an object.
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    // When the collider of a bullet and the collider of an enemy collide then
    // the enemy's health is reduced.
    // Destroys the bullet and istantiates an effect.
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Venus-Enemy" || col.gameObject.tag == "Boss-Enemy")
        {
            col.gameObject.GetComponent<EnemyHealthManager>().hurtEnemy(damage); // call the method hurtEnemy(damage) form the script EnemyHealthManager.

            Instantiate(bulletEffect, transform.position, transform.rotation); // instantiate  the bullet effect.

            Destroy(gameObject);
        }

        else if (col.gameObject.name == "player")
        {
            col.isTrigger = false;
        }

        else if(col.gameObject.tag == "Boss")
        {
            col.gameObject.GetComponent<BossHealthManager>().hurtEnemy(damage);
            Instantiate(bulletEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Instantiate(bulletEffect, transform.position, transform.rotation);

           
        }
        
    }
}
