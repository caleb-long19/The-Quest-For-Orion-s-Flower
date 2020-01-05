using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator playerAnim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerAnim.SetTrigger("isPressed"); // If the player collides with the button, switch button to isPressed in the Animator
            Debug.Log("Button has been Pressed");
        }
    }
}
