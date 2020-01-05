using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject Blood; // Blood particles for enemy
    public int damage = 5;

    public float arrowSpeed;
    public Rigidbody2D myRigidbody2D;


    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidbody2D.velocity = velocity.normalized * arrowSpeed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Die();
    }

    private void OnBecameInvisible()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
