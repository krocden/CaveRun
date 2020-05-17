using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

    // Variables for class and player
    public GameObject[] classList;
    private string currentClass;
    public static GameObject Clone;
    public Camera cam;

    private void Start ()
    {
        // Spawn player
        SpawnCharacter();
    }

    // Spawn player with the class the User chooses at the class selection scene
    // and attaches the camera to the player when it spawns
    private void SpawnCharacter()
    {
        for (int i = 0; i < classList.Length; i++)
        {
            if (classList[i].name == CharacterSelection.playerClass)
            {
                Clone = Instantiate(classList[i], new Vector3(0, 0, 0), Quaternion.identity);
                cam.GetComponent<NewCameraController>().player = Clone.GetComponent<Transform>();
            }
        }
    }
	
}
