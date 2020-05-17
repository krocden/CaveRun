using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalDoorScript : MonoBehaviour {

    public Transform door;
    public static int doorIndex;
    public Text getKeyText; // Text variable to tell the User that
                            // a key is needed for the door

    // Text for the key is set to false
    private void Start()
    {
        getKeyText.gameObject.SetActive(false);
        door = transform;
        getKeyText.text = "You Need a Key to Open This Door";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision of door and player
        if (collision.gameObject.CompareTag("Player"))
            print("player hit door");
        {
            // Open the door (by destroying the door gameobject) if key is true
            if (GameObject.Find("GameManager").GetComponent<PlayerStats>().isKey == true)
            {
                door = transform;
                FindDoorIndex();
                spawnController.getFinalSpawnerIndex();
                gameObject.SetActive(false);                
            }
            else if (GameObject.Find("GameManager").GetComponent<PlayerStats>().isKey == false)
            {
                // Activate text in the scene
                print("need Key");
                DisplayMessageKey();
            }
        }
    }

    // Find correct door 
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
    // Show to the user that a text is needed to open the door
    private void DisplayMessageKey()
    {
        print("Key text");
        getKeyText.gameObject.SetActive(true);
        StartCoroutine(hideText());
    }

    // Hide the text after 5 second
    IEnumerator hideText()
    {
        yield return new WaitForSeconds(5);
        getKeyText.gameObject.SetActive(false);
    }

        
    }
