using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour {
        
    // Variables for projectile spell.
    // Determine damage, cooldown and mana

    public float spellmana;

    public float cooldown;    
    public GameObject ultimateProjectile;
    public GameObject regularProjectile;
    public static float minDamage = 3;      // Damage is static to allow it to be increased
    public static float maxDamage = 15;
    public float projectileForce;

    private float nextFire;

    AudioSource aud1;
    

    public Animator animator;
    void Start()
    {
        aud1 = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        basicSpell();
    }

    // Basic spell (projectile)
    void basicSpell()
    {
        if (Input.GetMouseButtonDown(0) && 
            GameObject.Find("GameManager").GetComponent<PlayerStats>().mana > spellmana && GUIScripts.isGamePaused == false) 
        {
            // Attack Animation
            animator.SetTrigger("Attack");          
            
            // Create a gameobject from the prefab of the spell
            GameObject spell = Instantiate(regularProjectile, new Vector3(transform.position.x,transform.position.y,-1), Quaternion.identity);
            
            // Shoot it toward the mouse
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos);
            
            // Force depends on mouse location (Further from player = more force and speed)
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            
            // Randomize damage dealt to make game more dynamic
            // Prevent every enemy to die in the same amount of spell
            spell.GetComponent<TestProjectile>().damage = Random.Range(minDamage, maxDamage);

            // Destroy the spell afterward
            Destroy(spell, 2f);
            
            // Reduce mana
            GameObject.Find("GameManager").GetComponent<PlayerStats>().mana -= spellmana;

            // Sound effect
            aud1.PlayOneShot((AudioClip)Resources.Load("FireBallSFX")); 
        }
        // Ultimate spell
        // Same code as basic spell but damage is doubled and different prefab
        else if (Input.GetMouseButtonDown(1) && Time.time > nextFire && GUIScripts.isGamePaused == false)
        {
            animator.SetTrigger("Attack");
            nextFire = Time.time + cooldown;
            GameObject bigSpell = Instantiate(ultimateProjectile, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos);
            bigSpell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            bigSpell.GetComponent<TestProjectile>().damage = Random.Range(2 * minDamage, 2 * maxDamage);
            Destroy(bigSpell, 2f);
            GameObject.Find("GameManager").GetComponent<PlayerStats>().mana -= spellmana;
            aud1.PlayOneShot((AudioClip)Resources.Load("FireBallSFX"));

        }
    }
    


}



