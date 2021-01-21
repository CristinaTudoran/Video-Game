using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

//Mutes the audio playing in "gameoverbutton1", in scenes other than that.
public class gameOverMuter : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "gameoverbutton1"){
            audioSource.mute = !audioSource.mute;
        }
    }
}