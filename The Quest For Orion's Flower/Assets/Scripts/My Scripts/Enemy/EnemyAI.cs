using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Variables
    public int enemyHp; // enemy health
    [SerializeField]
    public float EnemySpeed = 5.0f;
    [SerializeField]
    private float MinEnemyRange = 0;
    [SerializeField]
    private float MaxEnemyRange = 0;

    //Unity References
    private Transform Target;
    private Animator EnemyMovement;
    public GameObject Blood; // Blood particles for enemy
    private Rigidbody2D rigidBody2D;
    private Vector2 Movement;
    public AudioClip Hurt;

    public void Start()
    {
        EnemyMovement = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        Target = FindObjectOfType<TopDownCharacterController2D>().transform;
    }

    private void Update()
    {
        if(Vector3.Distance(Target.position, transform.position) <= MaxEnemyRange && Vector3.Distance(Target.position, transform.position)>= MinEnemyRange)
        {
            TrackPlayer();
        }

        if (enemyHp <= 0) // When Enemy Health is equal to 0 - Destroy them 
        {
            Destroy(gameObject); // if the enemies health reaches 0, the enemy will be destroyed
        }

    }

    public void TrackPlayer()
    {
        EnemyMovement.SetBool("enemyIsMoving", true);
        EnemyMovement.SetFloat("Horizontal", (Target.position.x - transform.position.x));
        EnemyMovement.SetFloat("Vertical", (Target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, Target.position, EnemySpeed * 0.01f);
    }

    public void TakeDamage(int damage) // Procedure for Enenmies taking damage from player
    {
        enemyHp -= damage; // Enemy health takes damage
        Instantiate(Blood, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(Hurt, this.gameObject.transform.position);
        Debug.Log("damage TAKEN"); // will inform me whether the player has hit the enemy
    }

    public void SetTarget(Transform newTarget)
    {
        Target = newTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Knockback")
        {
            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }

}

