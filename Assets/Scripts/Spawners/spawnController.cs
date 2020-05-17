using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnController : MonoBehaviour {
    
    // Unused variable
    //static spawnController SpawnController = new spawnController();

    public GameObject[] SpawnerList;
    
    private int keyroom;

    private static  int spawnerIndex;    

    // Make key spawn dynamically.
    // Random location of key each game
    private void Start()
    {
        // Adds the spawnKey Script to one of the spawners (chooses randomly)
        keyroom = Random.Range(0, SpawnerList.Length - 1); 
        SpawnerList[keyroom].AddComponent<KeySpawner>();
        spawnerIndex = 0;
    }

    // Set spawner to be true so the enemies can spawn
    private void Update()
    {
        SpawnerList[spawnerIndex].SetActive(true);
    }

    // Index of spawners
    public static void getSpawnerIndex()
    {
        spawnerIndex = DoorScript.doorIndex;
        print(spawnerIndex);      
        print("spawning enemies");
        
    }

    // Index of the final boss spawner
    public static void getFinalSpawnerIndex()
    {
        spawnerIndex = FinalDoorScript.doorIndex;
        print(spawnerIndex + "Final Door");
        print("Spawning Enemies");

    }

    
    

    

}
