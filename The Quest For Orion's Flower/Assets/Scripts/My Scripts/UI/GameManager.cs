using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("OrionFlower");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
