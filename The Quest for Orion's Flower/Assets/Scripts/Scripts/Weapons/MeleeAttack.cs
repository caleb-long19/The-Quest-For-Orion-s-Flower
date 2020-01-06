using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public static int damage = 10; // Integer Value for Players Attack Damage with Sword

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyAI EnemyHealth; // Get Enemies Health from EnemyAI Script
            EnemyHealth = collision.gameObject.GetComponent<EnemyAI>(); // When Players Melee Attack collides with Enemy, get the Enemy AI component
            EnemyHealth.TakeDamage(damage); // If collision tag is equal to Enemy, Enemy takes damage!
        }
    }

}