using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateButton : MonoBehaviour
{
    public GameObject Barrier;
    public AudioSource Press;

    public Animator ButtonAnimationController;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Crate"))
        {
            Barrier.SetActive(false);
            ButtonAnimationController.SetTrigger("isPressed"); // If the player collides with the button, switch button to isPressed in the Animator
            Debug.Log("Crate Button has been Pressed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            Barrier.SetActive(true);
            ButtonAnimationController.SetTrigger("isNotPressed");
    }
}
