using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour
{
    public int health = 100;
    public int shield = 50;
    public UnityEvent onDie;
    public OnDamagedEvent onDamagedHealth;
    public OnDamagedEvent onDamagedShield;

    public void TakeDamage(int damage)
    {
        shield -= damage;

        onDamagedShield.Invoke(shield);

        if (shield <= 1)
        {
            health -= damage;

            onDamagedHealth.Invoke(health);
        }

        if (health < 1)
        {
            onDie.Invoke();
        }
    }

    public void Update()
    {
        if(health > 100)
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
        else if(shield <= 0)
        {
            shield = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Shield"))
        {
            Debug.Log("Shield has been collected");
            shield += 25;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag.Equals("Health"))
        {
            Debug.Log("Health has been collected");
            health += 15;
            Destroy(collision.gameObject);
        }
    }
}

