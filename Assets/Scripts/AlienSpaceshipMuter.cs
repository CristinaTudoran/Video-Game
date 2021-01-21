using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

//Mutes the audio playing in "Arachae Final Boss Fight" in scenes other than that.
public class AlienSpaceshipMuter : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "Arachae Final Boss Fight")
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}
