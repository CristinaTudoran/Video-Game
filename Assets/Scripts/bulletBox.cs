using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the objects in the game from which the player can collect bullets.
// It allows the player to collect bullets after touching a bulletBox object.
// It sends information from the script Gun.
public class bulletBox : MonoBehaviour
{
    public int bulletcount = 10; // number of available bullets in the box

    private bool isOpen; // boolean to determine whether the bullets have been collected or not. 
    public GameObject obj;

    void Start()
    {
        isOpen = false;
    }

    // When the collider of the player and the collider of the bulletBox object collide it
    // allows the player to collect the available bullets. It updates the relevant value
    // by sending the information to the script Gun.
    // Changes the colour of the bulletBox objects to gray.

    void OnTriggerEnter2D(Collider2D other)
    {
        Gun pc = other.GetComponent<Gun>();
        if (pc != null && !isOpen)
        {
            if (pc.MyCurrBulletCount < pc.MyMaxBulletCount)
            {
                pc.ChangeBulletCount(bulletcount);//add the number of the bullet
                this.obj.GetComponent<Renderer>().material.color = Color.grey;
                isOpen = true;
            }
        }

    }
}