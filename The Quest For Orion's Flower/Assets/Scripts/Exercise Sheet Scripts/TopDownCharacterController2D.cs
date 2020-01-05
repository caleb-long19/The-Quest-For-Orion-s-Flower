using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopDownCharacterController2D : MonoBehaviour
{
    public float speed = 5.0f;
    AnimatorController myAnim;
    private Animator PlayerAnim;
    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        myAnim = AnimatorController.instance;
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rigidBody2D.velocity = new Vector2(x, y) * speed;
        rigidBody2D.angularVelocity = 0.0f;

        if (y == 0 && x == 0)
        {
            PlayerAnim.SetBool("isWalking", false);
        }
        else
        {
            PlayerAnim.SetBool("isWalking", true);
        }
    }
}
