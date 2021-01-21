using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

//Mutes the audio playing in "MarsScene", in scenes other than that.
public class marsMuter : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "marsScene")
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}
