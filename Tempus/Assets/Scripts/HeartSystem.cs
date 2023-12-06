using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool dead;
    public HealthPotionCounter potionCounter;

    private void Start()
    {
        life = hearts.Length;
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
            Destroy(hearts[life].gameObject);
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
            Instantiate(hearts[life - 1], transform); // Instantiate a new heart prefab or use the existing one
        }
    }
}

