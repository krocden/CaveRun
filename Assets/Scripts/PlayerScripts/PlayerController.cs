using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Variables for character speed
    private Vector2 direction;
    public float speed = 1f;
    public float runspeed = 2f;
    float currentspeed = 0f;                // new speed variable for animation purpose
                                            // Used to detect if player is currently moving
    
    private enum Facing { UP, DOWN, LEFT, RIGHT};
    private Facing FacingDir = Facing.LEFT;
    private Vector2 targetPos;

    private GameObject Player;

    private SpriteRenderer mySpriteRenderer;
    public Animator animator;   

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Create a clone of the player prefab
    private void Start()
    {
        Player = PlayerSpawner.Clone;        
    }

    // Dynamic elements for character
    // Movement and sprite
    private void Update()
    {
        Move();                      // Move character
        takeInput();                 // Take input from user tosee which direction to move toward
        IsPlayerMoving();
        flipShoot();

        // Animation

        //Death animation if hp is 0 or below

        if (GameObject.Find("GameManager").GetComponent<PlayerStats>().health <= 0)
        {

            animator.SetBool("Death", true);
        }

        animator.SetFloat("Speed", Mathf.Abs(currentspeed));    // Speed parameter in Animation

        // Flip sprite depending on direction character is facing
        if (mySpriteRenderer != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
                mySpriteRenderer.flipX = false;
        }

    }
    private void IsPlayerMoving()        // If the player one of the WASD key to see if
    {                                   // the player is moving or not. For animations
        if (Input.GetKey(KeyCode.W))
        {
            currentspeed = speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentspeed = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentspeed = speed;
        }
        else if (Input.GetKey(KeyCode.D))
        { 
            currentspeed = speed;
        }  
        else
        {
           currentspeed = 0;
        }
    }
    private void Move()
    {
        GetComponent<Transform>().Translate(direction * speed * Time.deltaTime);
        
    }

    // Take keyboard input to make movement
    private void takeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            FacingDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            FacingDir = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            FacingDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            FacingDir = Facing.RIGHT;
        }

        if (Input.GetKeyDown(KeyCode.Space))    // Space is used as running button
        {
            speed *= runspeed;                  // Change moving speed
        }
        else if (Input.GetKeyUp(KeyCode.Space))     //  Return to default speed
        {
            speed /= runspeed;
        }      
       
    }

    // Flip character sprite depending on mouse location
    // Prevent shooting behind character for logical purpose
    public void flipShoot()
    {
        var playerScreenPoint = Camera.main.WorldToScreenPoint(Player.transform.position);
        if(Input.mousePosition.x < playerScreenPoint.x)
        {
            mySpriteRenderer.flipX = true;
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }

    // Prevent bugs where gameobject can still move during death animation
    public void deathStop()
    {
        speed = 0;
    }
}

