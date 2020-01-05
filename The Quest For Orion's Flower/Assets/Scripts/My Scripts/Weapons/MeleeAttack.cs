using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public static int damage = 10; // Sword Attack Damage

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyAI EnemyHealth;
            EnemyHealth = collision.gameObject.GetComponent<EnemyAI>();
            EnemyHealth.TakeDamage(damage); // If collision tag is equal to Enemy, Enemy takes damage!
        }
    }

}
