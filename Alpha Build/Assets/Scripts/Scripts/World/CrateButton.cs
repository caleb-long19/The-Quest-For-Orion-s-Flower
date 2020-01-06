using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateButton : MonoBehaviour
{
    //GameObjects
    public GameObject Barrier; // GameObject for Stone Barriers

    //Unity References
    public Animator ButtonAnimationController; // Reference for the Animator Component

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Crate"))
        {
            Barrier.SetActive(false); // Barrier GameObject is set to Inactive
            ButtonAnimationController.SetTrigger("isPressed"); // If the Crate collides with the Button, switch button to isPressed in the Animator

            Debug.Log("Crate Button has been Pressed"); // Display Debug Log in Console
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Barrier.SetActive(true); // Stone Barrier GameObject is set to active
        ButtonAnimationController.SetTrigger("isNotPressed"); // If the Crate isn't colliding with the button, switch button to isNotPressed in the Animator
    }
}
