using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1; // Unpauses the game
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("OrionFlower"); // Loads a scene called "OrionFlower"
    }

    public void Exit()
    {
        Application.Quit(); // Quits the application
    }
}
