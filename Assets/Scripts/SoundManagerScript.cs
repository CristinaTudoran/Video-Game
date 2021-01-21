using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plays a sound effect according to an event.
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip gameOverSound, gunFireSound, playerDeathSound, alienDeathSound, grenadeSound;
    static AudioSource audioSrc;

    void Start()
    {
        gameOverSound = Resources.Load<AudioClip>("gameOverSound");
        gunFireSound = Resources.Load<AudioClip>("gunFireSound");
        playerDeathSound = Resources.Load<AudioClip>("playerDeathSound");
        alienDeathSound = Resources.Load<AudioClip>("alienDeathSound");
        grenadeSound = Resources.Load<AudioClip>("grenadeSound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gameOverSound":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "gunFireSound":
                audioSrc.PlayOneShot(gunFireSound);
                break;
            case "playerDeathSound":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "alienDeathSound":
                audioSrc.PlayOneShot(alienDeathSound);
                break;
            case "grenadeSound":
                audioSrc.PlayOneShot(grenadeSound);
                break;
        }
    }
}
