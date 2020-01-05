using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{
    //Integers
    public int health = 100;
    public int shield = 50;
    public static int currentHP;

    //UI Elements
    public OnDamagedEvent onDamagedHealth;
    public OnDamagedEvent onDamagedShield;

    public new AudioClip audio;

    public void Start()
    {
        currentHP = health;
}

    public void TakeDamage(int damage)
    {
        shield -= damage;

        onDamagedShield.Invoke(shield);

        if (shield <= 1)
        {
            health -= damage;

            onDamagedHealth.Invoke(health);
        }

    }

    public void Update()
    {

        if (currentHP > health)
        {
            currentHP = health; // if current Hp is greater than the max hp, current hp is set to max hp (100)
        }

        if (currentHP <= 0)
        {
            gameObject.SetActive(false); // if Players current hp is less than or equal to 0, perform Die() procedure
        }


        if (health > 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            health = 0;
        }

        if (shield > 50)
        {
            shield = 50;
        }
        else if (shield <= 0)
        {
            shield = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Shield"))
        {
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            Debug.Log("Shield has been collected");
            shield += 25;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Health"))
        {
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            Debug.Log("Health has been collected");
            health += 15;
            Destroy(collision.gameObject);
        }
    }
}

