using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource bgmSource; // Reference to the AudioSource component for background music

    void Start()
    {
        // Load and play background music
        PlayBackgroundMusic();
    }

    // Method to play background music
    private void PlayBackgroundMusic()
    {
        // Load the background music audio clip from resources
        AudioClip bgmClip = Resources.Load<AudioClip>("BackgroundMusic");

        // Check if the audio clip is loaded successfully
        if (bgmClip != null)
        {
            // Set the audio clip to the AudioSource component
            bgmSource.clip = bgmClip;

            // Play the background music
            bgmSource.Play();
        }
        else
        {
            Debug.LogError("Failed to load background music audio clip!");
        }
    }

    // Method to set the volume of the background music
    public void SetVolume(float volume)
    {
        bgmSource.volume = volume;
    }
}
