using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the prefab Oxygen Station.
// It allows the player to collect oxygen from the oxygen stations by touching them.
// It calls the method addOxygen() from the script PlayerOxygenManager so that the oxygen value
// is updated when the player collects oxygen.
// It Stops the flickering animation to indicate that all the available oxygen has been collected.

public class OxygenStation : MonoBehaviour
{
    public int oxygenAvailable;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "player")
        {
            // call addOxygen() form PlayerOxygenManager script.
            col.gameObject.GetComponent<PlayerOxygenManager>().addOxygen(oxygenAvailable);

            // Variable to check if oxygenAvailable is positive.
            int x = oxygenAvailable - col.gameObject.GetComponent<PlayerOxygenManager>().oxygenUntilFull;

            if (x > 0)
            {
                oxygenAvailable -= col.gameObject.GetComponent<PlayerOxygenManager>().oxygenUntilFull; //update the oxygen available.
            }

            else
            {
                oxygenAvailable = 0; //if negative set it to zero.
            }

            if (oxygenAvailable == 0)
            {

                GetComponent<Animator>().enabled = false;

            }
        }
    }
}
