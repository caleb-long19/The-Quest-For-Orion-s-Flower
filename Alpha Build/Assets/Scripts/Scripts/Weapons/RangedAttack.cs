using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    //Integers
    public int damage = 5; // Integer value for Bow and Arrow

    //Floats
    public float arrowSpeed; // The speed in which an Arrow travels

    // Unity References
    public Rigidbody2D myRigidbody2D; // Get the Animator Component
    public GameObject Blood; // Blood particles GameObject for enemy


    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody2D.velocity = velocity.normalized * arrowSpeed; // RigidBody2D velocity (Speed) for the Bow and Arrow
        transform.rotation = Quaternion.Euler(direction);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver); // If arrow collides with Enemy, Enemy will take damage
        Die(); // Destroy Arrow
    }


    private void OnBecameInvisible()
    {
        Die(); // Destroy Arrow
    }


    private void Die()
    {
        Destroy(gameObject); // Destroy Arrow
    }
}
