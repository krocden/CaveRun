using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyShooting : MonoBehaviour {

    // Script might not be used in the actual game as all enemy are melee and not ranged
    // so no shooting is happening for now 

    // Variables for projectile
    // Enemy shooting 
    public GameObject projectile;
    public Transform player;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float cooldown;

    private void Start()
    {
        player = PlayerSpawner.Clone.GetComponent<Transform>();
        StartCoroutine(shootPlayer());
    }
    // Shoot player method
        IEnumerator shootPlayer()
        {
            // Shoot toward the player every few second depending on cooldown
            // Only if player is existing
            yield return new WaitForSeconds(cooldown);
            if (player != null)
            {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 myPos = transform.position;
            Vector2 targetPos = player.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<TestEnemyProjectile>().damage = Random.Range(minDamage, maxDamage);
            Destroy(spell, 2.0f);
            StartCoroutine("shootPlayer");
            }            
        }
    }

