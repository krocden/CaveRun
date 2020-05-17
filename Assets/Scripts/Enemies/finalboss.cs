using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalboss : MonoBehaviour {

    GameObject portal;

    // Find portal object in scene with tag portal
    private void Start()
    {
        portal = GameObject.FindGameObjectWithTag("portal");
        portal.SetActive(false);
    }

    // When the object this script is attached to is destroyed, run method
    public void OnDestroy()
    {
        spawnPortal();
    }

    // Set portal gameobject to be active
    public void spawnPortal()
    {
        portal.SetActive(true);
    }
}
