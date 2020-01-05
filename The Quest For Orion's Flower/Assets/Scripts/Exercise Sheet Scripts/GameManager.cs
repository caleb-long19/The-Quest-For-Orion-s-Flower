using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

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
