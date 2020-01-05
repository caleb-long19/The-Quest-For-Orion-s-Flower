using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //Variables
    public int EnemyHealth; // enemy health

    [SerializeField]
    public float EnemySpeed = 5.0f;

    [SerializeField]
    private float MinEnemyRange = 0;

    [SerializeField]
    private float MaxEnemyRange = 0;

    //Unity References
    public GameObject Blood; // Blood particles for Enemies
    private Rigidbody2D rigidBody2D; // Reference to Unity Physics
    private Animator EnemyMovement; // Reference to Unity Animator
    private Transform Target; // Reference to Player position
    private Vector2 Movement;
    public AudioClip Hurt;

    public void Start()
    {
        EnemyMovement = GetComponent<Animator>(); // EnemyMovement is equal to Animator Component on gameObject
        rigidBody2D = GetComponent<Rigidbody2D>(); // rigidBody2D is equal to RigidBody2D Component on gameObject
        Target = FindObjectOfType<TopDownCharacterController2D>().transform; // Target is equal to Player
    }

    private void Update()
    {
        if(Vector3.Distance(Target.position, transform.position) <= MaxEnemyRange && Vector3.Distance(Target.position, transform.position)>= MinEnemyRange)
        {
            TrackPlayer();
        }

        if (EnemyHealth <= 0)
        {
            Destroy(gameObject); // When EnemyHealth is equal to 0, Destroy Enemy gameObject
            Coin.score += 25; // Add 25 points to Players Score
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
        Instantiate(Blood, transform.position, Quaternion.identity); // When Enemy is damaged play blood particle effect
        AudioSource.PlayClipAtPoint(Hurt, this.gameObject.transform.position); // Play Enemy Hurt sound effect when Damaged
        EnemyHealth -= damage; // Enemies Health takes damage from Player

        Debug.Log("Enemy has Taken Damage!");
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
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y); // When Player deals damage to Enemy, Enemy gets knocked back
        }
    }

}

