using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Preserves the data of the player and the enemies across the scenes using
// the built-in method DontDestroyOnLoad().
// It also prevents duplication of both of them when the player revisits a scene
// by checking if there is more than one respective parent Game Object in the scene
// and destroying it in this case.
public class Preserve : MonoBehaviour
{
    void Awake()
    {
        GameObject[] marsEnemies = GameObject.FindGameObjectsWithTag("PreserveMarsEnemies");
        GameObject[] venusEnemies = GameObject.FindGameObjectsWithTag("PreserveEnemies");
        GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");
        GameObject[] bossEnemies = GameObject.FindGameObjectsWithTag("PreserveBossEnemies");
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        if (marsEnemies.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if (venusEnemies.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if (boss.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if (bossEnemies.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if (player.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }
}