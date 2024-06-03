using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the volume slider UI element
    public AudioController audioController; // Reference to the AudioController script

    void Awake()
    {
        // Ensure the GameObject containing the VolumeSlider script is active
        gameObject.SetActive(true);
    }

    // Method called when the slider value changes
    public void OnVolumeChanged()
    {
        // Get the current value of the slider
        float volume = volumeSlider.value;

        // Call the SetVolume method of the AudioController script to adjust the volume
        if (audioController != null)
        {
            audioController.SetVolume(volume);
        }
    }
}

