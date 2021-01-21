using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Updates the tet displayed on screen about the number of available bullets and grenades.
 // It requests this information from the script Gun.
public class UImanager : MonoBehaviour
{
    public static UImanager instance { get; private set; }
    public Gun updateNumberOfBullets;
    public Gun updateNumberOfGrenades;
    public Text bulletcountText;
    public Text grenadecountText;

    public void Update()
    {
        grenadecountText.text = "Grenades: " + updateNumberOfGrenades.currGrenadeCount + "/" + updateNumberOfGrenades.maxGrenadeCount;
        bulletcountText.text = "Bullet: " + updateNumberOfBullets.currBulletCount + "/" + updateNumberOfBullets.maxBulletCount;
    }
}


