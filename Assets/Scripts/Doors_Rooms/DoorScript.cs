using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Transform door;
    public static int doorIndex;

    private void Start()
    {
        door = transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if door enter in collision with Player
        if (collision.CompareTag("Player"))
        {
            // Open the door with the same index then disable door
            door = transform;
            print(door);           
            FindDoorIndex();
            spawnController.getSpawnerIndex();
            gameObject.SetActive(false);            
        }
    }

    // Find the index of the door to know which spawner to activate
    private void FindDoorIndex()
    {        
        for (int i = 0; i < transform.parent.childCount; i++)
        {           
            if (door == transform.parent.GetChild(i).transform)
            {
                doorIndex = i;                
                print(doorIndex);
            }           
        }
        
    }

}
