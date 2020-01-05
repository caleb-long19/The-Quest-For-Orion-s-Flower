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

    private new AudioSource audio;
    public new AudioClip Hurt;
    public GameObject Blood; // Blood particles for enemy

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

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
        Instantiate(Blood, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(Hurt, this.gameObject.transform.position);
        Debug.Log("damage TAKEN"); // will inform me whether the player has hit the enemy
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerCollision = true;
            audio.Play();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerCollision = false;
        audio.Stop();
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}

