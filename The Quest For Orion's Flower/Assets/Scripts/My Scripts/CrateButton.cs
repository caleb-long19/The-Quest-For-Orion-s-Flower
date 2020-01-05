using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateButton : MonoBehaviour
{
    public GameObject Barrier;

    public Animator ButtonAnimationController;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Crate"))
        {
            Destroy(Barrier);
            ButtonAnimationController.SetTrigger("isPressed"); // If the player collides with the button, switch button to isPressed in the Animator
            Debug.Log("Crate Button has been Pressed");
        }
    }
}
