using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys the sign above the objects from which the player can collect bullets or grenades.
// Before, it requires information from the Gun script to determine whether there is space
// for the items to be collected.
public class alertDisappear : MonoBehaviour
{        
    void OnTriggerEnter2D(Collider2D alert)
    {
        
        Gun pc = alert.GetComponent<Gun>();  
        if (pc != null)
        {
            if (pc.MyCurrBulletCount < pc.MyMaxBulletCount)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
