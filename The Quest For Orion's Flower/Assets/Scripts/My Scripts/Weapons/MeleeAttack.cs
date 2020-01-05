using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public static int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyAI EnemyHealth;
            EnemyHealth = collision.gameObject.GetComponent<EnemyAI>();
            EnemyHealth.TakeDamage(damage);
        }
    }

}
