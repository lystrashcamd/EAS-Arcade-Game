using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Ensure this object persists across scenes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Swipe Menu") // Change "Menu" to the name of your menu scene
        {
            Merge.spawnedYet = "n";
            // Reset other static variables here if needed
        }
    }

    // Remember to remove event registration when this object is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
