using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour {

    private GameObject key;

    private void Start()
    {
        //assign the key in the scenes to the script
        key = GameObject.Find("key");
        //spawns the key
        var currentposition = transform.localPosition;
        Instantiate(key, currentposition, transform.rotation);
    }
}
