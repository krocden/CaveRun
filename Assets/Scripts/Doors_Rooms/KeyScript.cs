using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // If player enter contact with key, then boolean is set to true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<PlayerStats>().isKey = true;
            Destroy(gameObject);
        }
    }
}
