﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController2D : MonoBehaviour
{
    public static float speed = 5.0f;
    public static float PlayerSpeed;
    public Animator Player;
    Rigidbody2D rigidBody2D;
    Vector2 Movement;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerSpeed = rigidBody2D.angularVelocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");

        Player.SetFloat("Horizontal", Movement.x);
        Player.SetFloat("Vertical", Movement.y);
        Player.SetFloat("Speed", Movement.sqrMagnitude);

        rigidBody2D.velocity = new Vector2(Movement.x, Movement.y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

    }

}
