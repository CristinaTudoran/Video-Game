using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

//Mutes the audio playing in "venusScene, in scenes other than that.
public class venusMuter : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "venusScene")
        {
            audioSource.mute = !audioSource.mute;
        }
    }
}
