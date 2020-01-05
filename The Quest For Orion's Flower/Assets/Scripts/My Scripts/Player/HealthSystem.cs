using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{
    //Integers
    public static int health = 100;
    public static int shield = 50;

    //Unity References
    public AudioClip HealthPickup;

    public void TakeEnemyDamage(int damage) // (Linked to HurtTrigger Script)
    {
        shield -= damage; // When Enemy collides with Player, Shield takes damage 

        if (shield <= 1)
        {
            health -= damage; // If Shield is less than or equal to 1, Player can lose Health

        }
    }

    public void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false); // if Players currentHP is less than or equal to 0, disable Player
        }

        if (health >= 100)
        {
            health = 100; // If health is > 100, health is equal to 100
        }

        if (shield > 50)
        {
            shield = 50; // If shield is > 50, shield is equal to 50
        }
        else if (shield <= 0)
        {
            shield = 0; // If shield is <= 0, shield is equal to 0
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Shield"))
        {
            AudioSource.PlayClipAtPoint(HealthPickup, this.gameObject.transform.position); // When Player collides with Shield Pickup, play sound effect
            shield += 25; // When Player collides with Shield Pickup, add 25 to Shield integer
            Destroy(collision.gameObject); // When Player Collides with Shield Pickup, destroy Shield Pickup
        }

        if (collision.gameObject.tag.Equals("Health"))
        {
            AudioSource.PlayClipAtPoint(HealthPickup, this.gameObject.transform.position); // When Player collides with Shield Pickup, play sound effect
            health += 15; // When Player collides with Health Pickup, add 15 to Health integer
            Destroy(collision.gameObject); // When Player Collides with Health Pickup, destroy Health Pickup
        }
    }
}

