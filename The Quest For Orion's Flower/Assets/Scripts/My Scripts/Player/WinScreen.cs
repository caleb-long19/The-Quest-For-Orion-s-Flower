using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject Win; // Attatch gameObject called DeathMenu in unity
    public GameObject Player; // Player GameObject
    public GameObject Dad; // Dad NPC GameObject
    public GameObject Mum; // Mum NPC GameObject
    public GameObject DialogDad;
    public GameObject DialogMum;

    private void Start()
    {
        Win.SetActive(false); // When the Game Starts, Win Screen is inactiv
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.Space) & collision.tag.Equals("Player") && KeyPickup.OrionFlower == true)
        {
            Win.SetActive(true); // When Player collides with Main House and has Orion's Flower, Win Screen is Active
            Player.SetActive(false); // Player is set to Inactive
            Dad.SetActive(false); // Dad NPC is set to Inactive
            Mum.SetActive(false); // Mum NPC is set to Inactive
            DialogDad.SetActive(false);
            DialogMum.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // When Restart Button is Selected, Reload Scene
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu"); // When Exit Button is pressed, Exit to Main Menu Sceen
        Debug.Log("You have quit the game!");
    }
}
