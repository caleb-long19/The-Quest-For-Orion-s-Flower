using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour
{
    public Transform target;
    public bool PlayerCollision;
    public float speed = 5.0f;
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

