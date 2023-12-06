using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private int hiddenHeartsCount; // New variable to track hidden hearts
    private bool dead;
    public HealthPotionCounter potionCounter;

    private void Start()
    {
        life = hearts.Length;
        hiddenHeartsCount = 0; // Initialize the count to 0
    }

    void Update()
    {
        if (dead)
        {
            // SET DEAD CODE
            Debug.Log("WE ARE DEAD");
        }

        // Check for the 'H' key press to use the health potion
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHealthPotion();
        }
    }

    public void TakeDamage(int damage)
    {
        if (life >= 1)
        {
            life -= damage;

            if (life >= 0 && life < hearts.Length)
            {
                hearts[life].SetActive(false);
                hiddenHeartsCount++;
            }

            if (life < 1)
            {
                dead = true;
            }
        }
    }

    // Method to use the health potion
    private void UseHealthPotion()
    {
        // Check if there are potions available
        if (potionCounter != null && potionCounter.GetPotionCount() > 0)
        {
            // Use the potion, increase health, and decrease potion count
            Heal(1);
            potionCounter.DecreasePotionCount();
        }
    }

    // Method to increase player's health
    public void Heal(int amount)
    {
        if (life < hearts.Length)
        {
            life = Mathf.Min(life + amount, hearts.Length);

            if (hiddenHeartsCount > 0)
            {
                hearts[life - 1].SetActive(true);
                hiddenHeartsCount--;
            }
            else
            {
                Instantiate(hearts[life - 1], transform); // Instantiate a new heart prefab or use the existing one
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "Damaging"
        if (other.CompareTag("Damaging"))
        {
            // Adjust the damage amount as needed
            Debug.Log("Hit");
            int damageAmount = 1;
            TakeDamage(damageAmount);
        }
    }
}
