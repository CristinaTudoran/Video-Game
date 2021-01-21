using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// This script is attached to the GameOverButton object. it destroys all enemies before the user can start a new game.
public class GameOverButton : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("TheMainMenu");
        GameObject[] marsEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] venusEnemies = GameObject.FindGameObjectsWithTag("Venus-Enemy");
        GameObject venusEnemiesObject = GameObject.FindGameObjectWithTag("PreserveEnemies");
        GameObject marsEnemiesObject = GameObject.FindGameObjectWithTag("PreserveMarsEnemies");
        GameObject bossEnemiesObject = GameObject.FindGameObjectWithTag("PreserveBossEnemies");
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");

        foreach (GameObject i in marsEnemies)
        {
            Destroy(i);
        }

        foreach (GameObject j in venusEnemies)
        {
            Destroy(j);
        }

        Destroy(venusEnemiesObject);
        Destroy(marsEnemiesObject);
        Destroy(bossEnemiesObject);
        Destroy(boss);
    }


}
