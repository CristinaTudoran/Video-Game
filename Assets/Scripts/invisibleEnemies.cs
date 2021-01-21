using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is attached to the enemies in the game and makes them invisible in other scenes
// other than the one instantiated.It also disables the colliders so that they can not hurt the player.
public class invisibleEnemies : MonoBehaviour
{
    void Update()
    {
        if ((SceneManager.GetActiveScene().name != "marsScene" && gameObject.tag == "Enemy") || (SceneManager.GetActiveScene().name != "venusScene" && gameObject.tag == "Venus-Enemy") || 
            (SceneManager.GetActiveScene().name != "Arachae Final Boss Fight" && gameObject.tag == "Boss-Enemy") || (SceneManager.GetActiveScene().name != "Arachae Final Boss Fight" && gameObject.tag == "Boss"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
