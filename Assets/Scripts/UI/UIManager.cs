using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider volumeSlider; // Reference to your volume slider in the Unity Editor

    void Start()
    {
        // Set the min and max values of the volumeSlider
        volumeSlider.minValue = 0f; // Minimum value (typically for mute)
        volumeSlider.maxValue = 1f; // Maximum value (full volume)
    }
}
