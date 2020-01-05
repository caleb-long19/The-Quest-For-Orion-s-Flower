using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Variables
    public int enemyHp; // enemy health
    public bool PlayerCollision;
    public float speed = 5.0f;

    //Unity References
    public Transform target;
    public Animator EnemyMovement;
    protected Vector2 Movement;

    private void Update()
    {
        if (PlayerCollision == true)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
            }

        }

        if (enemyHp <= 0)
        {
            Destroy(gameObject); // if the enemies health reaches 0, the enemy will be destroyed
        }

    }

    public void TakeDamage(int damage) // Procedure for Enenmies taking damage from player
    {
        enemyHp -= damage; // Enemy health takes damage
        Debug.Log("damage TAKEN"); // will inform me whether the player has hit the enemy
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerCollision = true;
            EnemyMovement.SetBool("Attack", true);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCollision = false;
        EnemyMovement.SetBool("Attack", false);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}

