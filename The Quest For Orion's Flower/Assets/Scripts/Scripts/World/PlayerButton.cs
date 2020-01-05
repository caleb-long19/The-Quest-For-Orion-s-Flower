using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    public GameObject Barrier;
    public AudioClip ButtonPressPlayer;

    public Animator ButtonAnimationController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            ButtonAnimationController.SetTrigger("isPressed"); // If the player collides with the button, switch button to isPressed in the Animator
            AudioSource.PlayClipAtPoint(ButtonPressPlayer, this.gameObject.transform.position); // Play Button Sound Effect
            Destroy(Barrier); // Destroy Stone Barrier

            Debug.Log("Player Button has been Pressed");
        }
    }
}
