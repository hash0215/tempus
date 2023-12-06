using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healingAmount = 1;
    public HealthPotionCounter potionCounter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HeartSystem playerHealth = other.GetComponent<HeartSystem>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healingAmount); // Increase player's health

                // Check if potionCounter is not null before using it
                if (potionCounter != null)
                {
                    potionCounter.IncreasePotionCount(); // Update potion counter
                    Debug.Log("Health potion collected by player.");
                }
                else
                {
                    Debug.LogError("potionCounter is null in HealthPotion.cs. Assign a HealthPotionCounter component in the Unity Editor.");
                }

                // Destroy the health potion GameObject
                Destroy(gameObject);
            }
        }
    }
}
