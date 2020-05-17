using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    // Variables for spawner
    List<GameObject> prefabList = new List<GameObject>();

    // Variables for gameobject of the spawner
    public GameObject orc;
    public GameObject orc2;
    public GameObject orc3;
    public GameObject key;  
    
    // Variables for mob spawned, current mob per spawner and max mob per spawner
    public int maxmob = 0;
    public int currentmob = 0;
    public int mobSpawned = 0;

    // Use this for initialization
	void Start () {
		prefabList.Add(orc);
        prefabList.Add(orc2);
        prefabList.Add(orc3);
        spawn();        
	}

    // Spawn mobs dynamically
    void spawn() {
        // Only make dynamic spawning for normal enemy and not boss
        // Spawn random mobs except for boss so boss is only spawned once
        // All our enemy are the same so you can't differentiate from the enemy
        // But it could spawn 2 enemies of the 1st prefab and none from the 2nd prefab
        // or 1 of each prefab
        if (prefabList[0].name == "Orc" || prefabList[0].name == "Orc 2")
        {
            for (int i = 0; i < 3; i++)
            {
                var spawnrangex = Random.Range(transform.position.x - 3, transform.position.x + 3);
                var spawnrangey = Random.Range(transform.position.y - 3, transform.position.y + 3);
                var currentposition = new Vector2(spawnrangex, spawnrangey);
                Instantiate(prefabList[Random.Range(0, 2)], currentposition, transform.rotation);
                print("spawed at : " + currentposition);
            }
        }
        else
        {
            // Spawn method only used for bosses where the spawning is not dynamic
            for (int i = 0; i < 3; i++)
            {
                var spawnrangex = Random.Range(transform.position.x - 3, transform.position.x + 3);
                var spawnrangey = Random.Range(transform.position.y - 3, transform.position.y + 3);
                var currentposition = new Vector2(spawnrangex, spawnrangey);
                Instantiate(prefabList[i], currentposition, transform.rotation);
                print("spawed at : " + currentposition);
            }
        }
    }
    
    
    
}
