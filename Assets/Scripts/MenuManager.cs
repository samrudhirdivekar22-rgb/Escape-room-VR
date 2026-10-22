using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Scene build indexes
    private const int MAIN_MENU_INDEX = 0;
    private const int LEVEL1_INDEX = 1;

    /// <summary>
    /// Loads the Main Menu scene (Build Index 0).
    /// Wire this to a UI Button's OnClick event in the Inspector.
    /// </summary>
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_INDEX);
    }

    /// <summary>
    /// Loads Level 1 - Ordinary Room (Build Index 1).
    /// Wire this to a UI Button's OnClick event in the Inspector.
    /// </summary>
    public void GoToLevel1()
    {
        SceneManager.LoadScene(LEVEL1_INDEX);
    }

    /// <summary>
    /// Restarts the currently active scene.
    /// Wire this to a UI Button's OnClick event in the Inspector.
    /// </summary>
    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Quits the application.
    /// Wire this to a UI Button's OnClick event in the Inspector.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
