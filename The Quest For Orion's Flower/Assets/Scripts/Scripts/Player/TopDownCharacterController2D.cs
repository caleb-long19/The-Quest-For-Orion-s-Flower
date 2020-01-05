using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController2D : MonoBehaviour
{
    //Player Floats
    public static float speed = 5.0f; // Players Movement Speed
    public static float PlayerSpeed; // Player Speed for Rigid Body 2D

    //Sword Floats
    public float attackCounter; // Attack counter for Melee Attack
    public float attackTime; // Attack Time for Melee Attack


    //Bow and Arrow Floats
    public float fireTime = 0.5f; // Firing time for the Bow and Arrow

    //Bools
    public bool isAttacking; // bool for Sword, is the Player Attacking or Not
    private bool isFiring = false; // bool for Bow, is the Player Firing the Bow or Not

    //Unity References
    public Animator Player; // Animator component for the Player
    public Rigidbody2D rigidBody2D; // RigidBody2D component for the Player
    public Vector2 Movement; // Vector Player Movement on the X, Y Axis
    public GameObject ArrowObject; // GameObject for Arrow
    public AudioClip Bow; // Audio Clip for Bow and Arrow


    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); // Get RigidBody2D component from GameObject
    }

    private void Update()
    {
        #region Players Movement and Last Known Position in X, Y values
        PlayerSpeed = rigidBody2D.angularVelocity;

        Movement.x = Input.GetAxis("Horizontal"); // Store Players Horizontal Position in Movement.X Vector
        Movement.y = Input.GetAxis("Vertical"); // Store Players Vertical Position in Movement.Y Vector

        Player.SetFloat("Horizontal", Movement.x); // Players Movement of the X Axis is stored in Player Animator Parameter "Horizontal"
        Player.SetFloat("Vertical", Movement.y); // Players Movement of the Y Axis is stored in Player Animator Parameter "Vertical"
        Player.SetFloat("Speed", Movement.sqrMagnitude);

        rigidBody2D.velocity = new Vector2(Movement.x, Movement.y) * speed; // Players RigidBody2D Velocity is equal to their X,Y Position Multiplied by the Players Speed
        rigidBody2D.angularVelocity = 0.0f;

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            Player.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal")); // Stores players last known X position
            Player.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical")); // Stores players last known Y position
        }
        #endregion

        #region Sword and Bow If Statements
        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                Player.SetBool("isAttacking", false); // If the attackCounter is <= 0, Player is no longer attacking
                isAttacking = false; // isAttacking is set to false
            }
        }

        if (KeyPickup.SwordPickup == true) // If the Player has picked up the Sword, they can attack enemies
        {
            if (Input.GetKey(KeyCode.Mouse0)) // If Player Left Clicks, Run If Statement
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
                Fire(); // If Player isn't firing the bow, Call Fire Method
                Ammo.ammo -= 1; // Remove 1 arrow from arrow counter
                AudioSource.PlayClipAtPoint(Bow, this.gameObject.transform.position); // Play Bow Firing SFX
            }
        }
        #endregion
    }

    #region Bow and Arrow Methods
    private void Fire() // Method for firing the bow
    {
        isFiring = true; // isFiring bool is set to true
        Vector2 temp = new Vector2(Player.GetFloat("lastMoveX"), Player.GetFloat("lastMoveY")); // Store Players last known X,Y position in temp variable
        RangedAttack arrow = Instantiate(ArrowObject, transform.position, Quaternion.identity).GetComponent<RangedAttack>(); // Instantiates the arrow prefab
        arrow.Setup(temp, ArrowDirection()); // arrow variable stores Player Postion and calulates position of arrow
        Invoke("SetFiring", fireTime); // Activate the time between firing arrows
    }

    Vector3 ArrowDirection() // Method to determine the direction of the arrow
    {
        float temp = Mathf.Atan2(Player.GetFloat("lastMoveY"), Player.GetFloat("lastMoveX")) * Mathf.Rad2Deg; // Determines the last position the player was facing to determine the direction of the arrow
        return new Vector3(0, 0, temp);
    }

    private void SetFiring()
    {
        isFiring = false; // isFiring bool is set to false
    }
    #endregion
}

