using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public AudioSource backgroundMusic; // Reference to the AudioSource for background music

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        // Fade out the background music
        float startVolume = backgroundMusic.volume;
        float currentTime = 0.0f;
        float fadeDuration = 3.0f; // Adjust this duration for the fade-out

        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            backgroundMusic.volume = Mathf.Lerp(startVolume, 0.0f, currentTime / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene("Cutscene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
