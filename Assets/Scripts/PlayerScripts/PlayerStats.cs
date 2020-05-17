using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;

    // Key to open door
    public bool isKey;

    // Variables for UI text
    public Text healthText;
    public Text manaText;
    public Text expText;
    public Text levelText;

    // Variables for UI slider
    public GameObject manaBar;
    public Slider manaBarSlider;
    public GameObject healthBar;
    public Slider healthBarSlider;
    public GameObject expBar;
    public Slider expBarSlider;

    // Variables for character stats 
    // Health, Mana, Level, Exp, Spell mana
    public float spellmana;
    public float health;
    public float maxHealth;
    public float mana;
    public float maxMana;
    public float passiveManaGain;
    public float exp;
    public float maxExp;
    float leftoverExp;
    float level = 1;
    public float expMod;        // Modifier increasing exp needed for each level


    //variable for sounds
    private AudioSource aud1;

    // Variables to count score and mob killed
    public static int MobKilled = 0;
    public static int score = 0;

    public Animator animator; 

    // Reset player stats to default if existing
    private void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
    }

    void Start()
    {
        isKey = false;              // No key when starting game
        print("Player Set");
        health = maxHealth;        // Set stats to full
        mana = maxMana;
        exp = 0;
        setHeathUI();
        aud1 = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        // Constant update on UI
        // Allow stats to update
        findPlayer();
        expBarSlider.value = CalculateExpPercentage();
        LevelUp();
        manaBarSlider.value = CalculateManaPercentage();
        passiveMana();
        statUpdate();
    }
    //used to find the player and player animator
    private void findPlayer()
    {        
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();       
    }
    // Set health UI slider
    private void setHeathUI()
    {
        healthBarSlider.value = CalculateHealthPercentage();
    }
    // Set animation and calculate health when hit
    public void dealDamage(float damage)
    {
        health -= damage;
        checkDeath();
        setHeathUI();
        if(health > 0)
        {
            animator.SetTrigger("Hurt");
            aud1.PlayOneShot((AudioClip)Resources.Load("Steve Old Hurt Sound"));
        }
        healthBarSlider.value = CalculateHealthPercentage();
    }
    // Prevent overheal as well as mana
    private void checkOverHeal()
    {
        if (health > maxHealth) // Change healh and mana value to max when above the max value
        {
            health = maxHealth;
        }
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }
    // Method to heal character
    private void healCharacter(float heal)
    {
        health += heal;
        checkOverHeal();
        setHeathUI();
        healthBarSlider.value = CalculateHealthPercentage();
    }
    // Method to check death when health is below 0 or equal to 0
    private void checkDeath()
    {
        if (health <= 0)
        {            
            health = 0;
            setHeathUI();
            Destroy(player, 1);
            GUIScripts.GameOver();
            player.GetComponent<PlayerController>().deathStop();
        }
    }

    // Calculate health
    public float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }
    // Calculate mana
    public float CalculateManaPercentage()
    {
        return mana / maxMana;
    }

    // Gain mana overtime
    public void passiveMana()
    {
        if (mana < maxMana)
        {
            mana += passiveManaGain;
        }
        checkOverHeal();
    }
    // Calculate experience
    float CalculateExpPercentage()
    {
        return exp / maxExp;
    }
    // Method to level up
    void LevelUp()
    {
        if (exp >= maxExp)
        {
            maxHealth += 10;
            leftoverExp = exp - maxExp;
            maxExp *= expMod;
            exp = leftoverExp;
            level += 1;
            setHeathUI();
            health = maxHealth;
            mana = maxMana;
            setHeathUI();
            Spell.minDamage *= 1.1f;
            Spell.maxDamage *= 1.1f;
        }     
    }
    // Method to set text in the UI
    void statUpdate()
    {
        healthText.text = health + "/" + maxHealth; 
        manaText.text = mana + "/" + maxMana; 
        expText.text = Mathf.Round(exp) + "/" + Mathf.Round(maxExp);
        levelText.text = "Level: " + level;
    }
    
}