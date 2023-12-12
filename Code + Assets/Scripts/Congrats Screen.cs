using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CongratsScreen : MonoBehaviour
{
    public GameObject scrollArea;
    public Button backButton;

    public void Setup() 
    {
        gameObject.SetActive(true);
    }

    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextStage()
    {
        // Get the current scene build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by adding 1 to the current build index
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ShowScrollArea()
    {
        // Check if the Scroll Area reference is assigned
        if (scrollArea != null)
        {
            // Toggle the visibility of the Scroll Area
            scrollArea.SetActive(!scrollArea.activeSelf);

            if (backButton != null)
            {
                backButton.gameObject.SetActive(scrollArea.activeSelf);
            }
        }
    }

    public void DeactivateScrollArea()
    {
        scrollArea.SetActive(false);
        if (backButton != null)
        {
            backButton.gameObject.SetActive(false); // Deactivate the button
        }
    }

}
