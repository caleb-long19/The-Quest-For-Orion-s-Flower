using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject SettingsScreen;
    public GameObject ControlsScreen;

    private bool paused = false; // boolean set for pause menu

    private void Start()
    {
        PauseScreen.SetActive(false); // When the game starts, the pause menu is set to false

    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused; // if "escape" is pressed, pause the game
        }

        if (paused)
        {
            PauseScreen.SetActive(true); // When true the pause menu is displayed
            Time.timeScale = 0; // The time in game is frozen when game is paused
        }

        if (!paused)
        {
            PauseScreen.SetActive(false); // When false the pause menu is not displayed
            Time.timeScale = 1; // The time in game is back to normal when game is not paused
        }

        if(SettingsScreen.activeInHierarchy || ControlsScreen.activeInHierarchy)
        {
            if (PauseScreen.activeInHierarchy)
            {
                PauseScreen.SetActive(false); // When false the pause menu is not displayed
                Time.timeScale = 0; // The time in game is back to normal when game is not paused
            }

            if (Input.GetButtonDown("Pause"))
            {
                PauseScreen.SetActive(false);
                SettingsScreen.SetActive(false);
                ControlsScreen.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        paused = false; // When the Resume Button is pressed, Pause Menu is False
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // When the Restart Button is pressed, reload current level
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu"); // When Exit Button is pressed, Exit to main menu
        Debug.Log("You have quit the game!");
    }
}
