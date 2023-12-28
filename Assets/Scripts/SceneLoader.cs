using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void RestartGame()
    {
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentSceneIndex);
        Time.timeScale = 1.0f;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int levelToUnlock = PlayerPrefs.GetInt("LevelToUnlock");

        if (levelToUnlock < currentSceneIndex)
        {
            PlayerPrefs.SetInt("LevelToUnlock", currentSceneIndex);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void UnPauseTheGame()
    {
        Time.timeScale = 1.0f;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
    }

    public void QuitTheGame()
    {
        Application.Quit();
        Debug.Log("Pressed");
    }
}
