using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the objects in the game from which the player can collect grenades.
// It allows the player to collect grendes after touching a grenadeCollect object.
// It calles the method ChangeGrenadeCount() from the script Gun to update the available number of grenades.
public class GrenadeCollect : MonoBehaviour
{
    public int grenadetcount = 10; //number of the grenades in the box.

    private bool isOpen; // boolean to determine whether the bullets have been collected or not. 
    public GameObject obj;
    void Start()
    {
        isOpen = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Gun pc = other.GetComponent<Gun>();
        if (pc != null && !isOpen)
        {
            // When the collider of the player and the collider of the object collide it
            // allows the player to collect the available grenades. It updates the relevant value
            // by sending the information to the script Gun.
            // Changes the colour of the object to gray.
            if (pc.MyCurrGrenadeCount < pc.MyMaxGrenadeCount)
            {
                pc.ChangeGrenadeCount(grenadetcount);//add the number of the bullet
                this.obj.GetComponent<Renderer>().material.color = Color.grey;
                //Destroy(this.gameObject);
                isOpen = true;
            }
        }
    }
}