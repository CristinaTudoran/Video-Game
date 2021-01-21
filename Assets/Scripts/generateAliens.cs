using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script is attached to the  object ALIEN BOSS. If the scene Arachae Final Boss Fight is currently the active scene
// it generates a new alien there every some specified amount of time.
public class generateAliens : MonoBehaviour
{
    public GameObject bossSceneAlien;

    private Transform preserveEnemiesObject;

    void Start()
    {   
        preserveEnemiesObject = GameObject.FindGameObjectWithTag("PreserveBossEnemies").transform;
            StartCoroutine(Time()); // starts counting.
    }

    IEnumerator Time()
    {
        while (true)
        {
            if (SceneManager.GetActiveScene().name == "Arachae Final Boss Fight")
            {
                Instantiate(bossSceneAlien, new Vector3(Random.Range(550f, 554f), -440.24f, 0), Quaternion.identity, preserveEnemiesObject); // generate a new alien
                yield return new WaitForSeconds(10f); // wait 15secs and then repeat.
            }
        }
    }

}
