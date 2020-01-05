using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //Integers
    public static int ammo = 0; // Integer for Players Ammo Count

    //Unity References
    public AudioClip AmmoPickup; // Audio Clip for the Ammo Pickup

    private void Start()
    {
        ammo = 0; // When the game starts, ammo is equal to 0
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Player")) //If "Player" collides with coin add 20 points and destroy object
        {
            AudioSource.PlayClipAtPoint(AmmoPickup, this.gameObject.transform.position); // Play audio when Item is picked up
            ammo += 5; // When Player Collides with Ammo, add to Ammo Counter
            Destroy(gameObject); // Destroy object when Player Collides

            Debug.Log("Player Has Collided!");
        }
    }
}
