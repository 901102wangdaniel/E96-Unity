using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject gameObjectPrefab; // Reference to the prefab of the GameObject to be moved

    void Start()
    {
        // Load the new scene
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
    }

    void Update()
    {
        // Check if the new scene is loaded
        if (SceneManager.GetSceneByName("SampleScene").isLoaded)
        {
            // Instantiate the GameObject prefab in the new scene
            Instantiate(gameObjectPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            // Optionally, destroy the GameObject in the old scene
            Destroy(gameObject);
        }
    }
}
