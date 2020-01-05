using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject DeathScreen; // Attatch gameObject called DeathMenu in unity

    private void Start()
    {
        DeathScreen.SetActive(false); // When the game starts, the pause menu is not displayed
    }

    private void Update()
    {

        if (HealthSystem.currentHP <= 0)
        {
            DeathScreen.SetActive(true); // When player health is equal to 0, DeathMenu is true
        }

        if (HealthSystem.currentHP >= 1)
        {
            DeathScreen.SetActive(false); // When player health is equal to >=1, DeathMenu is false
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // when the restart button is pressed, reload current level
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu"); // when exit is pressed, close down game
        Debug.Log("You have quit the game!");
    }
}
