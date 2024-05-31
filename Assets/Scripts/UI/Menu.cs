using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] public string SceneName;
    public Slider volumeSlider; // Reference to the volume slider in the options panel
    public AudioController audioManager; // Reference to the AudioController script

    void Start()
    {
        // Set the initial volume value of the slider to the current volume level
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel", 0.5f);
    }

    public void PlayGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName); 
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    // Method to adjust the volume of the background music
    public void SetVolume(float volume)
    {
        // Save the volume level to PlayerPrefs for persistence
        PlayerPrefs.SetFloat("VolumeLevel", volume);
        PlayerPrefs.Save();

        // Set the volume of the audio manager
        if (audioManager != null)
        {
            // audioManager.SetVolume(volume);
        }
    }
}
