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

        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        Player.SetFloat("Horizontal", Movement.x);
        Player.SetFloat("Vertical", Movement.y);
        Player.SetFloat("Speed", Movement.sqrMagnitude);

        rigidBody2D.velocity = new Vector2(Movement.x, Movement.y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            Player.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            Player.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        if (isAttacking)
        {
            rigidBody2D.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                Player.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        if (KeyPickup.SwordPickup == true)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                attackCounter = attackTime;
                Player.SetBool("isAttacking", true);
                isAttacking = true;
            }
        }

        if (Input.GetMouseButton(1) && KeyPickup.BowPickup == true && Ammo.ammo >= 1)
        {
            if (!isFiring)
            {
                Fire();
                Ammo.ammo -= 1;
                AudioSource.PlayClipAtPoint(Bow, this.gameObject.transform.position);
            }
        }
    }


    private void Fire()
    {
        isFiring = true;
        Vector2 temp = new Vector2(Player.GetFloat("lastMoveX"), Player.GetFloat("lastMoveY"));
        RangedAttack arrow = Instantiate(ArrowObject, transform.position, Quaternion.identity).GetComponent<RangedAttack>();
        arrow.Setup(temp, ArrowDirection());
        Invoke("SetFiring", fireTime);
    }

    Vector3 ArrowDirection()
    {
        float temp = Mathf.Atan2(Player.GetFloat("lastMoveY"), Player.GetFloat("lastMoveX")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    private void SetFiring()
    {
        isFiring = false;
    }
}

