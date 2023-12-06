using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider

    private void Start()
    {
        // Add a listener to the slider that calls the SetVolume method when the value changes
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);

            // Set the initial volume (you may want to load this from player preferences)
            float defaultVolume = 0.5f; // Set to halfway (0.0 to 1.0)
            volumeSlider.value = defaultVolume; // Set the slider value
            SetVolume(defaultVolume); // Set the initial volume

            // If you want to load the volume from player preferences, uncomment the following line:
            // SetVolume(PlayerPrefs.GetFloat("Volume", defaultVolume));
        }
        else
        {
            Debug.LogError("Volume Slider is not assigned to the VolumeControl script.");
        }
    }

    // Method called when the slider value changes
    private void SetVolume(float volume)
    {
        // Adjust the volume using the AudioListener
        AudioListener.volume = volume;

        // Save the volume value to player preferences
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save(); // Save preferences immediately (optional)
    }
}
