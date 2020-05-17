using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    private void Awake()
    {       
        //keep the song playing through levels
        DontDestroyOnLoad(gameObject);
    }
    
}
