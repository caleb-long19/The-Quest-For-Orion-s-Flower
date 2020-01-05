using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController2D : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rigidBody2D;
    public Animator PlayerMovement;

    Vector2 Movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        PlayerMovement.SetFloat("Horizontal", Movement.x);
        PlayerMovement.SetFloat("Vertical", Movement.y);
        PlayerMovement.SetFloat("Speed", Movement.sqrMagnitude);

        rigidBody2D.velocity = new Vector2(Movement.x, Movement.y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

    }
}
