using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool ForestKey;
    public static bool FrostKey;
    public static bool DesertKey;

    public static bool ForestOrb;
    public static bool FrostOrb;
    public static bool DesertOrb;
    public static bool OrionFlower;

    public static bool BowPickup;
    public static bool SwordPickup;

    public static bool AllOrbs;
    public AudioClip Keys;
    public AudioClip OrbPickup;
    public AudioClip Pickup;

    public void Start()
    {
        ForestKey = false;
        FrostKey = false;
        DesertKey = false;

        SwordPickup = false;
        BowPickup = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ForestKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position);
            ForestKey = true;
            Destroy(GameObject.FindWithTag("ForestKey"));
        }

        if (collision.gameObject.tag.Equals("FrostKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position);
            FrostKey = true;
            Destroy(GameObject.FindWithTag("FrostKey"));
        }

        if (collision.gameObject.tag.Equals("DesertKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position);
            DesertKey = true;
            Destroy(GameObject.FindWithTag("DesertKey"));
        }


        if (collision.gameObject.tag.Equals("ForestOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            ForestOrb = true;
            Destroy(GameObject.FindWithTag("ForestOrb"));
        }

        if (collision.gameObject.tag.Equals("FrostOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            FrostOrb = true;
            Destroy(GameObject.FindWithTag("FrostOrb"));
        }

        if (collision.gameObject.tag.Equals("DesertOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            DesertOrb = true;
            Destroy(GameObject.FindWithTag("DesertOrb"));
        }

        if (collision.gameObject.tag.Equals("OrionFlower"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position);
            OrionFlower = true;
            Destroy(GameObject.FindWithTag("OrionFlower"));
        }

        if (collision.tag == "Sword")
        {
            AudioSource.PlayClipAtPoint(Pickup, this.gameObject.transform.position);
            SwordPickup = true;
            Destroy(GameObject.FindWithTag("Sword"));
        }


        if (collision.tag == "Bow")
        {
            AudioSource.PlayClipAtPoint(Pickup, this.gameObject.transform.position);
            BowPickup = true;
            Destroy(GameObject.FindWithTag("Bow"));
        }
    }

    public void Update()
    {
        if (ForestOrb == true && FrostOrb == true && DesertOrb == true)
        {
            AllOrbs = true;
        }
    }

}
