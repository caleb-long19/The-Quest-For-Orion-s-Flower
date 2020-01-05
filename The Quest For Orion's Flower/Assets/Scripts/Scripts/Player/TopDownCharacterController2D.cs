using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController2D : MonoBehaviour
{
    //Floats
    public static float speed = 5.0f;
    public static float PlayerSpeed;
    public float fireTime = 0.5f;
    public float attackCounter;
    public float attackTime;

    //Bools
    public bool isAttacking;
    private bool isFiring = false;

    //Unity References
    public Animator Player;
    public Rigidbody2D rigidBody2D;
    public Vector2 Movement;
    public GameObject ArrowObject;
    public AudioClip Bow;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); // Get RigidBody2D component from GameObject
    }

    private void Update()
    {
        PlayerSpeed = rigidBody2D.angularVelocity;

        Movement.x = Input.GetAxis("Horizontal"); // Get player X axis 
        Movement.y = Input.GetAxis("Vertical"); // Get player Y axis 

        Player.SetFloat("Horizontal", Movement.x); // Player speed on X axis
        Player.SetFloat("Vertical", Movement.y); // Player speed on Y axis
        Player.SetFloat("Speed", Movement.sqrMagnitude); // Players overall speed

        rigidBody2D.velocity = new Vector2(Movement.x, Movement.y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            Player.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal")); // Stores players last known X position
            Player.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical")); // Stores players last known Y position
        }

        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                Player.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (KeyPickup.SwordPickup == true) // If sword pickup is equal to true player can attack
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                attackCounter = attackTime;
                Player.SetBool("isAttacking", true); // Play attacking animation
                isAttacking = true; // Set isAttacking to true
            }
        }

        if (Input.GetMouseButton(1) && KeyPickup.BowPickup == true && Ammo.ammo >= 1) // The player can fire an arrow if they press "Left Click", If they picked up the bow, and if they have more than 0 arrows
        {
            if (!isFiring)
            {
                Fire(); // Call Fire Method
                Ammo.ammo -= 1; // Remove 1 arrow from arrow counter
                AudioSource.PlayClipAtPoint(Bow, this.gameObject.transform.position);
            }
        }
    }

    private void Fire() // Method for firing the bow
    {
        isFiring = true;
        Vector2 temp = new Vector2(Player.GetFloat("lastMoveX"), Player.GetFloat("lastMoveY"));
        RangedAttack arrow = Instantiate(ArrowObject, transform.position, Quaternion.identity).GetComponent<RangedAttack>(); // Instantiates the arrow prefab
        arrow.Setup(temp, ArrowDirection());
        Invoke("SetFiring", fireTime);
    }

    Vector3 ArrowDirection() // Method to determine the direction of the arrow
    {
        float temp = Mathf.Atan2(Player.GetFloat("lastMoveY"), Player.GetFloat("lastMoveX")) * Mathf.Rad2Deg; // Determines the last position the player was facing to determine the direction of the arrow
        return new Vector3(0, 0, temp);
    }

    private void SetFiring()
    {
        isFiring = false;
    }
}

