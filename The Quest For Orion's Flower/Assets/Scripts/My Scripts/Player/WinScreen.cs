using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject Win; // Attatch gameObject called DeathMenu in unity
    public GameObject Player;
    public GameObject Dad;
    public GameObject Mum;

    private void Start()
    {
        Win.SetActive(false); // When the game starts, the pause menu is not displayed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player") && KeyPickup.OrionFlower == true)
        {
            Win.SetActive(true);
            Player.SetActive(false);
            Dad.SetActive(false);
            Mum.SetActive(false);
        }
    }
}
