using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour {

    public Transform player; 
    public float smoothing;
    public Vector3 offset;

    // New script to allow the camera to follow the player
    void FixedUpdate()
    {
        if (player != null)
        {            
            
            Vector3 newPostion = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = newPostion;
        }
    }
}
