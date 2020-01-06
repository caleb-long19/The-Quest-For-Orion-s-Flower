using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{
    //Integers
    public static int health = 100; // Integer value for Players Health
    public static int shield = 50; // Integer value for Players Shield

    //Unity References
    public Animator HealthBarAnimation;
    public Animator ShieldBarAnimation;
    public AudioClip HealthPickup; // Audio Clip for both Health and Shield Pickup

    private void Start()
    {
        health = 100; // Player Health is equal to 100 when game starts
        shield = 50; // Player Shielf is equal to 50 when game starts
    }
    public void TakeEnemyDamage(int damage) // (Linked to HurtTrigger Script)
    {
        shield -= damage; // When Enemy collides with Player, Shield takes damage 
        ShieldBarAnimation.SetBool("isDamagedShield", true);
        HealthBarAnimation.SetBool("isDamagedHealth", false);

        if (shield <= 1)
        {
            health -= damage; // If Shield is less than or equal to 1, Player can lose Health
            HealthBarAnimation.SetBool("isDamagedHealth", true);
            ShieldBarAnimation.SetBool("isDamagedShield", false);
        }
    }

    public void Update()
    {
        #region Players Health
        if (health <= 0)
        {
            gameObject.SetActive(false); // if Players currentHP is less than or equal to 0, disable Player GameObject
        }

        if (health >= 100)
        {
            health = 100; // If health is > 100, health is equal to 100
            HealthBarAnimation.SetBool("isDamagedHealth", false);
        }
        #endregion

        #region Players Shield
        if (shield >= 50)
        {
            shield = 50; // If shield is > 50, shield is equal to 50
            ShieldBarAnimation.SetBool("isDamagedShield", false);
        }
        else if (shield <= 0)
        {
            shield = 0; // If shield is <= 0, shield is equal to 0
        }
        #endregion
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        #region Collision If Statements for Player
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
        #endregion
    }
}

