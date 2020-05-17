using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour {

     private GameObject player;
     private GameObject target;
     public float AttackCooldown = 1f;
     public int damage = 5;
     public int MoveSpeed = 4;
     public int MaxDist = 10; // Distance to walk toward toward player
     public int MinDist = 5; // 

    public Animator animator;
    private SpriteRenderer mySpriteRenderer;

    float timeColliding;  // Timer to track collision time

    //variable for sounds
    private AudioSource aud1;


    private void Start()
    {
        player = PlayerSpawner.Clone;
        aud1 = gameObject.AddComponent<AudioSource>();
    }
    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        flipAttack();
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        // Make enemy follow the player if existing
        if (target != null)
        {
            float step = MoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Deal damage to the player when enemy touch the player
        if (collision.collider.CompareTag("Player"))
        {
            timeColliding = 0f; // Collision just happened so timer is 0
            PlayerStats.playerStats.dealDamage(damage);
            animator.SetTrigger("Collision Attack");
            //play the attack sound
            aud1.PlayOneShot((AudioClip)Resources.Load("Thrall Claw Attack Sound Effect First Variation"));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // If the player is in constant collision with enemy
        // Prevent the player to touch the enemy once to receive damage
        // and stay on top of the enemy without receiving additional damage
        if (collision.collider.CompareTag("Player"))
        {
            if (timeColliding < AttackCooldown)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                // Time is over theshold, player takes damage
                PlayerStats.playerStats.dealDamage(damage);
                animator.SetTrigger("Collision Attack");
                // Reset timer
                timeColliding = 0f;
                //play the attack sound
                aud1.PlayOneShot((AudioClip)Resources.Load("Thrall Claw Attack Sound Effect First Variation"));
            }
        }
    }

    // Method to flip the enemy sprite depending on the player location
    // Logical purpose where enemy is moonwalking when sprite is not flipping
    public void flipAttack()
    {
        var playerPos = player.transform.position;
        if(transform.position.x > playerPos.x) // Depending on X position
        {                                       // of player and enemy  
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }
}
