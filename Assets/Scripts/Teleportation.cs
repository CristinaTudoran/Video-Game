using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //reference to use SceneManager, which loads a new scene


/// <summary>
/// This class is used to transfer the player from one scene to another. 
/// </summary>

public class Teleportation : MonoBehaviour
{
    /// <summary>
    /// When the player colides with each teleportation portal, the OnTriggerEnter2D method is called. 
    /// It takes the tag of the object which collided with the portal and if it is 'Player' it checks the tag of the portal and it transfers the player to the respective scene. 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.tag == "transportToMars")
            {
                SceneManager.LoadScene("marsScene");
                GameObject obj = GameObject.FindGameObjectWithTag(Tag.player);
                obj.transform.position = new Vector3(-2346.77f, -692.17f, 0);
            }

            else if (gameObject.tag == "transportToMarsBuilding")
            {
                SceneManager.LoadScene("spaceStation 1");
                GameObject obj = GameObject.FindGameObjectWithTag(Tag.player);
                obj.transform.position = new Vector3(-2388.6f, -714.8f, 0);
            }
            else if (gameObject.tag == "transportToVenus")
            {
                SceneManager.LoadScene("venusScene");
                GameObject obj = GameObject.FindGameObjectWithTag(Tag.player);
                obj.transform.position = new Vector3(536.5f, -395.5f, 0);
            }
            else if (gameObject.tag == "transportToFinalLevel")
            {
                SceneManager.LoadScene("Arachae Final Boss Fight");
                GameObject obj = GameObject.FindGameObjectWithTag(Tag.player);
                obj.transform.position = new Vector3(552.8f, -457.98f, 0);
            }
        }
    }
}
