using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance = null; // Singleton instance
    public AudioSource bgmSource; // Reference to the AudioSource component for background music

    void Awake()
    {
        // Check if there is already an instance of AudioController
        if (instance == null)
        {
            // If not, set it to this instance
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent across scenes
        }
        // else if (instance != this)
        // {
        //     // If an instance already exists, destroy this one
        //     Destroy(gameObject);
        // }
    }

    void Start()
    {
        // Load and play background music
        PlayBackgroundMusic();
    }

    // Method to play background music
    private void PlayBackgroundMusic()
    {
        // Load the background music audio clip from resources
        AudioClip bgmClip = Resources.Load<AudioClip>("NightThemeAudio");

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
        // Mute audio if volume is set to 0
        if (volume == 0)
        {
            bgmSource.mute = true;
        }
        else
        {
            bgmSource.mute = false;
            bgmSource.volume = volume;
        }
    }
}
