using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject DeathScreen; // Attatch GameObject called DeathScreen in unity
    public TextMeshProUGUI scoreText; // Get Text Mesh Component to store Score Text from the UI

    private void Start()
    {
        DeathScreen.SetActive(false); // When Game Begins, Death Screen UI is disabled
    }

    private void Update()
    {
        if (HealthSystem.health <= 0)
        {
            DeathScreen.SetActive(true); // When player health is equal to 0, DeathScreen is active
            scoreText.text = "SCORE: " + Coin.score.ToString(); // Score Counter Text is equal to Integer Score
        }

        if (HealthSystem.health >= 1)
        {
            DeathScreen.SetActive(false); // When player health is equal to >= 1, DeathScreen is not active
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // When Restart Button is Selected, Reload Scene
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu"); // When Exit Button is pressed, Exit to Main Menu Sceen
        Debug.Log("You have quit the game!");
    }
}
