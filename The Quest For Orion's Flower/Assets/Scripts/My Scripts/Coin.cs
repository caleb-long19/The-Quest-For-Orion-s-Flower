using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : AddScore
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Player")) //If "Player" collides with coin add 20 points and destroy object
        {
            score = 20; // Every coin pickup equals to 20 points
            Debug.Log("Player Has Collided!");
            Destroy(gameObject);
        }
    }
}
