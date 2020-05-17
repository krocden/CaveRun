using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour {

    public float damage;

    // Method to deal damage. When collision between spell and enemy
    // Deal damage
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Doors"
            && collision.tag != "Spell") // Make sure correct enemy and doesn't destroy other important gameobjects
        {
            if (collision.CompareTag("Enemy Projectile")) // Destroy enemy projectile 
            {                                          // if player projectile collides with
                Destroy(collision);
            }
            else if (collision.GetComponent<EnemyReceiveDamage>() != null)
            {
                collision.GetComponent<EnemyReceiveDamage>().dealDamage(damage);
            }
            Destroy(gameObject); // Destroy spell
        }
              
    }

    // Deal damage but for ultimate. If spell stays on enemy, deal constant damage
    public void OnCollisionStay2D(Collision2D collision) 
    {
        if (collision.gameObject.tag != "Player" &&
            collision.gameObject.tag != "Doors")
        {
            if (collision.gameObject.CompareTag("Enemy Projectile"))
            {
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.GetComponent<EnemyReceiveDamage>() != null)
            {
                collision.gameObject.GetComponent<EnemyReceiveDamage>().dealDamage(damage/50);
            }
            
        }
        
    }

}

