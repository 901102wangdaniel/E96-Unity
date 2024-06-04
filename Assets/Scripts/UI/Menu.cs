using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private string SceneName = "MapScene"; // Default scene name
    public Slider volumeSlider; // Reference to the volume slider in the options panel

    void Start()
    {
        // Set the initial volume value of the slider to the current volume level
        if (AudioController.instance != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumeLevel", 0.5f);
            AudioController.instance.SetVolume(volumeSlider.value);
        }

        // Add a listener to the slider to update the volume in real-time
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneName); 
    }
    // Method to adjust the volume of the background music
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("VolumeLevel", volume);
        PlayerPrefs.Save();

        if (AudioController.instance != null)
        {
            AudioController.instance.SetVolume(volume);
        }
    }

    public void QuitGame() 
    {
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}

