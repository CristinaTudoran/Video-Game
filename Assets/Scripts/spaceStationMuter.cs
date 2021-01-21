using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

//Mutes the audio playing in "spaceStation 1", in scenes other than that.
public class spaceStationMuter : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "spaceStation 1")
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}
