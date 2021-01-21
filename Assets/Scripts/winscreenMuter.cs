using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

//Mutes the audio playing in "winscreen", in scenes other than that.
public class winscreenMuter : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "winscreen")
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}
