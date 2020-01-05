using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController2D : MonoBehaviour
{
    public static float speed = 5.0f;
    public static float PlayerSpeed;
    public Animator Player;
    public Rigidbody2D rigidBody2D;
    public Vector2 Movement;
    public bool isAttacking;
    public float attackCounter;
    public float attackTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
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
    }
}

