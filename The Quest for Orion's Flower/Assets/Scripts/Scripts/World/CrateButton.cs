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
            Barrier.SetActive(false); // Barrier GameObject is set to Inactive
            ButtonAnimationController.SetTrigger("isPressed"); // If the Crate collides with the button, switch button to isPressed in the Animator

            Debug.Log("Crate Button has been Pressed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Barrier.SetActive(true); // Barrier GameObject is set to active
        ButtonAnimationController.SetTrigger("isNotPressed"); // If the Crate isn't colliding with the button, switch button to isNotPressed in the Animator
    }
}
