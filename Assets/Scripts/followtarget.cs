using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tag {
public const string player = "Player";
}

// This script is attached to the main camera and is used so that the camera follows the player.
public class followtarget : MonoBehaviour
{
    public float smooth=3f;
    private Transform player;

    void Start () 
    {
    player = GameObject.FindGameObjectWithTag(Tag.player).transform;
    }

    // updates the position of the camera relatively to the position of the player.
    void Update () 
    {
    Vector3 targetposition = player.position +new Vector3(0,0,-10);
    transform.position = Vector3.Lerp(transform.position,targetposition,smooth*Time.deltaTime);
    }
}
