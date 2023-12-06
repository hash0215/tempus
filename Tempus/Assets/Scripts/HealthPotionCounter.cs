using UnityEngine;
using UnityEngine.UI;

public class HealthPotionCounter : MonoBehaviour
{
    private int potionCount = 0;
    public Text potionCountText; // Reference to the UI Text component

    // Method to increase the potion count
    public void IncreasePotionCount()
    {
        potionCount++;
        Debug.Log("Potion Count Increased: " + potionCount);

        // Update UI Text
        UpdateUIText();
    }

    // Method to decrease the potion count
    public void DecreasePotionCount()
    {
        if (potionCount > 0)
        {
            potionCount--;
            Debug.Log("Potion Count Decreased: " + potionCount);

            // Update UI Text
            UpdateUIText();
        }
    }

    // Method to get the current potion count
    public int GetPotionCount()
    {
        return potionCount;
    }

    // Method to update the UI Text
    private void UpdateUIText()
    {
        // Check if the UI Text reference is not null
        if (potionCountText != null)
        {
            potionCountText.text = "Potion Count: " + potionCount;
        }
        else
        {
            Debug.LogWarning("UI Text reference is not assigned in the HealthPotionCounter script.");
        }
    }

    private void Start()
    {
        // Set the initial value of the UI Text
        UpdateUIText();
    }
}
