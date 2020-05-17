using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveDamage : MonoBehaviour {

    public float health;
    public float maxHealth;
    public float mobExp;

    public GameObject healthBar;
    public Slider healthBarSlider;
    
   
    // Set health to max
    void Start()
    {
        health = maxHealth;
    }

    // Method to receive damage and set health bar
    public void dealDamage(float damage)
    {
        healthBar.SetActive(true);
        healthBarSlider.value = CalculateHealthPercentage();
        health -= damage;
        checkDeath();
    }

    // Prevent having health over max health
    private void checkOverHeal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    // Method to heal character
    private void healCharacter(float heal)
    {
        health += heal;
        checkOverHeal();
        healthBarSlider.value = CalculateHealthPercentage();
    }

    // Player dies when health is 0 or below. 
    private void checkDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //GameObject.Find("Spawner Orc").GetComponent<Spawner>().currentmob -= 1;
            GameObject.Find("GameManager").GetComponent<PlayerStats>().exp += mobExp;
            PlayerStats.MobKilled += 1;
            PlayerStats.score += 10;
        }
    }

    // Method to calculate health percentage. 
    // Used for UI health bar
    public float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
    
}
