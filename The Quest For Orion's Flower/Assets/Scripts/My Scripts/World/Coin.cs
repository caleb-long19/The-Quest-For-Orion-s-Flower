using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //Integers
    public static int score = 0;

    //Unity References
    public AudioClip CoinPickup;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) //If "Player" collides with coin add 20 points and destroy object
        {
            AudioSource.PlayClipAtPoint(CoinPickup, this.gameObject.transform.position); // Play audio in GameObjects position
            score += 20; // Every coin pickup equals to 20 points
            Destroy(gameObject); // Destroy Coin gameObject when Player collides

            Debug.Log("Player Has Collided!");
        }
    }
}
