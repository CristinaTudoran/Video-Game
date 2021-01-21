using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Threading;
using UnityEngine.SceneManagement;

// This script is attached to the player and manages the oxygen value. Every 5 seconds
// the current oxygen rebuces by 1 unit. When the oxygen value is zero the player is destroyed.
public class PlayerOxygenManager : MonoBehaviour
{
    public int playerMaxOxygen;
    public int playerCurrentOxygen;
    public int oxygenUntilFull;


    void Start()
    {
        playerCurrentOxygen = playerMaxOxygen;

        StartCoroutine(Time()); //starts counting.
    }

    // destroys the player if oxygen value is zero.
    void Update()
    {

        if (playerCurrentOxygen <= 0)
        {
            gameObject.SetActive(false);
		SceneManager.LoadScene("gameoverbutton1");
        }

    }


    IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(5); // wait 5 seconds
            playerCurrentOxygen--; // reduce the oxygen value by one unit

        }
    }

    // adds an amount of oxygen to the current value. This method is called from
    // the oxygenStation script so that the oxygen value is updated when the
    // player collects oxygen.
    // It guards against exceeding the max oxygen value.
    public void addOxygen(int oxygenToAdd)
    {
        oxygenUntilFull = playerMaxOxygen - playerCurrentOxygen;

        if (oxygenUntilFull > oxygenToAdd)
        {
            playerCurrentOxygen += oxygenToAdd;
        }

        else
        {
            playerCurrentOxygen = playerMaxOxygen;

        }
    }
}
