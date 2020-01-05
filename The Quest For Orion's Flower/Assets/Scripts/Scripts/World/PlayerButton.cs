using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    public GameObject Barrier; // GameObject for Stone Barrier
    public AudioClip ButtonPressPlayer; // Audio Clip for Button Press

    public Animator ButtonAnimationController; // Reference to Animator Component

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            ButtonAnimationController.SetTrigger("isPressed"); // If the player collides with the button, switch button to isPressed in the Animator
            AudioSource.PlayClipAtPoint(ButtonPressPlayer, this.gameObject.transform.position); // Play Button Sound Effect on button position
            Destroy(Barrier); // Destroy Stone Barrier when Player collides with button

            Debug.Log("Player Button has been Pressed");
        }
    }
}
