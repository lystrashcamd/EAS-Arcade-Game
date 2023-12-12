using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public void LoadScene()
    {
        string buttonName = gameObject.name; // Get the name of the button clicked

        // Check if the button name starts with "Level ("
        if (buttonName.StartsWith("Level ("))
        {
            // Extract the level number from the button's name
            int startIndex = buttonName.IndexOf('(') + 1;
            int endIndex = buttonName.IndexOf(')');
            string levelNumberStr = buttonName.Substring(startIndex, endIndex - startIndex);

            int levelNumber;
            if (int.TryParse(levelNumberStr, out levelNumber))
            {
                string sceneName = "Level " + levelNumber; // Form the scene name based on the level number
                SceneManager.LoadScene(sceneName); // Load the corresponding scene
            }
            else
            {
                Debug.LogError("Invalid button name format. Please name your buttons as 'Level (number)'.");
            }
        }
        else
        {
            Debug.LogError("Button name doesn't start with 'Level ('. Please name your buttons as 'Level (number)'.");
        }
    }
}
