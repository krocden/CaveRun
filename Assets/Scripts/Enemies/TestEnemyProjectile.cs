using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour {

    public float damage;

    // If projectile collide with enemy. Deal damage
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {           
            if (collision.tag == "Player")
            {                
                PlayerStats.playerStats.dealDamage(damage);               
            }
            Destroy(gameObject);
        }        
    }
}
