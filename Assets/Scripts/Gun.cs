using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// This script is attached to the gun object and handles the behaviour of the gun.
public class Gun : MonoBehaviour
{
    public GameObject grenadePrefab;
    public GameObject bullet;
    public Transform muzzleTransform;



    public Camera cam;
    private Vector3 mousePos;
    private Vector2 gunDirection;
    public int grenadeThrowForce;



    //max bullet number 
    public int maxBulletCount = 100;
    //max bullet number 
    public int maxGrenadeCount = 50;
    //bullet number now
    public int currBulletCount;



    public int currGrenadeCount;
    public int MyCurrGrenadeCount { get { return currGrenadeCount; } }
    public int MyMaxGrenadeCount { get { return maxGrenadeCount; } }



    public int MyCurrBulletCount { get { return currBulletCount; } }
    public int MyMaxBulletCount { get { return maxBulletCount; } }


    void Start()
    {
        currBulletCount = maxBulletCount;
        currGrenadeCount = 0;
        

    }

    void Update()
    {
        // Sets the gun direction to be where the mouse is pointing.
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        gunDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);


        // Instantiates a bullet when the left mouse button is pressed.
        if (Mouse.current.leftButton.wasPressedThisFrame && currBulletCount > 0)
        {
            
            Instantiate(bullet, muzzleTransform.position, Quaternion.Euler(transform.eulerAngles));
            ChangeBulletCount(-1); // updates number of available bullets.
            SoundManagerScript.PlaySound("gunFireSound");
        }

        // Instantiates a grenade when the left mouse button is pressed.
        if (Mouse.current.rightButton.wasPressedThisFrame && currGrenadeCount > 0)

        {
             Instantiate(grenadePrefab, muzzleTransform.position, Quaternion.Euler(transform.eulerAngles));
             ChangeGrenadeCount(-1); //updates number of available grenades.
        }
    }

    // Keeps track of the number of Bullets.
    public void ChangeBulletCount(int amount)
    {
        currBulletCount = Mathf.Clamp(currBulletCount + amount, 0, maxBulletCount); //limit the number of the bullet between 0-max.
        
    }
    // Keeps track of the number of grenades
    public void ChangeGrenadeCount(int amount)
    {
        currGrenadeCount = Mathf.Clamp(currGrenadeCount + amount, 0, maxGrenadeCount); //limit the number of the bullet between 0-max.    
    }
}