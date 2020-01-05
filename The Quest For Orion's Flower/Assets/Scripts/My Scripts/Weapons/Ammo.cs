using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //Integers
    public static int ammo = 0;

    //Unity References
    public AudioClip AmmoPickup;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Player")) //If "Player" collides with coin add 20 points and destroy object
        {
            AudioSource.PlayClipAtPoint(AmmoPickup, this.gameObject.transform.position); // Play audio clip when Player Collides
            ammo += 5; // When Player Collides with Ammo, add to Ammo Counter
            Debug.Log("Player Has Collided!");
            Destroy(gameObject); // Destroy object when Player Collides
        }
    }
}
