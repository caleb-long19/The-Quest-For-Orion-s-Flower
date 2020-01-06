using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    // Temple Key Bools
    public static bool ForestKey; // Bool for Forest Temple Key
    public static bool FrostKey; // Bool for Frost Temple Key
    public static bool DesertKey; // Bool for Desert Temple Key

    // Temple Orb Bools
    public static bool ForestOrb; // Bool for Forest Temple Orb
    public static bool FrostOrb; // Bool for Frost Temple Orb
    public static bool DesertOrb; // Bool for Desert Temple Orb
    public static bool AllOrbs; // Bool for all the Temple Orb
    public static bool OrionFlower; // Bool for Orion's Flower

    // Weapon Pickup Bools
    public static bool BowPickup; // Bool for Bow (Weapon)
    public static bool SwordPickup; // Bool for Sword (Weapon)

    //Unity References
    public AudioClip Keys; // Audio Clip for Temple Keys
    public AudioClip OrbPickup; // Aduio Clip for Temple Orbs
    public AudioClip Pickup; // Audio Clip for Weapon Pickup

    public void Start() // Set all bools to False on Start
    {
        #region Set all bools to false when game starts
        ForestKey = false;
        FrostKey = false;
        DesertKey = false;

        ForestOrb = false;
        FrostOrb = false;
        DesertOrb = false;
        OrionFlower = false;
        AllOrbs = false;

        SwordPickup = false;
        BowPickup = false;
        #endregion
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        #region All Methods For Temple Keys
        // When Player collides with Temple Keys, Remove object, Temple Key Bools are set to True, Play sound effect!
        if (collision.gameObject.tag.Equals("ForestKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position); // Play Audio Sample
            ForestKey = true; // Forest Key is equal to true
            Destroy(GameObject.FindWithTag("ForestKey")); // Destroy Forest Key
        }

        if (collision.gameObject.tag.Equals("FrostKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position); // Play Audio Sample
            FrostKey = true; // Frost Key is equal to true
            Destroy(GameObject.FindWithTag("FrostKey")); // Destroy Frost Key
        }

        if (collision.gameObject.tag.Equals("DesertKey"))
        {
            AudioSource.PlayClipAtPoint(Keys, this.gameObject.transform.position); // Play Audio Sample
            DesertKey = true; // Desert Key is equal to true
            Destroy(GameObject.FindWithTag("DesertKey")); // Destroy Desert Key
        }
        #endregion

        #region All Methods for Temple Orbs
        // When Player collides with Temple Orbs, Remove object, Temple Orb Bools are set to True, Play sound effect!
        if (collision.gameObject.tag.Equals("ForestOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position); // Play Audio Sample
            ForestOrb = true; // Forest Orb is equal to true
            Destroy(GameObject.FindWithTag("ForestOrb")); // Destroy Forest Orb
        }

        if (collision.gameObject.tag.Equals("FrostOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position); // Play Audio Sample
            FrostOrb = true; // Frost Orb is equal to true
            Destroy(GameObject.FindWithTag("FrostOrb")); // Destroy Frost Orb
        }

        if (collision.gameObject.tag.Equals("DesertOrb"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position); // Play Audio Sample
            DesertOrb = true; // Desert is equal to true
            Destroy(GameObject.FindWithTag("DesertOrb")); // Destroy Desert Orb
        }

        if (collision.gameObject.tag.Equals("OrionFlower"))
        {
            AudioSource.PlayClipAtPoint(OrbPickup, this.gameObject.transform.position); // Play Audio Sample
            OrionFlower = true; // Orion's Flower is equal to true
            Destroy(GameObject.FindWithTag("OrionFlower")); // Destroy Orion's Flower
        }
        #endregion

        #region All Methods for Weapon Pickups
        // When Player Collides with Weapons, Destroy them and set Weapon Bools to true
        if (collision.tag == "Sword")
        {
            AudioSource.PlayClipAtPoint(Pickup, this.gameObject.transform.position); // When Player collides with Sword, Play sound effect
            SwordPickup = true; // SwordPickup bool is set to true
            Destroy(GameObject.FindWithTag("Sword")); // Destroy Sword gameObject
        }


        if (collision.tag == "Bow")
        {
            AudioSource.PlayClipAtPoint(Pickup, this.gameObject.transform.position); // When Player collides with Bow, Play sound effect
            BowPickup = true; // BowPickup bool is set to true
            Destroy(GameObject.FindWithTag("Bow")); // Destroy Bow gameObject
        }
        #endregion
    }

    public void Update()
    {
        if (ForestOrb == true && FrostOrb == true && DesertOrb == true)
        {
            AllOrbs = true; // If all Forest Orb bools are equal to True, AllOrbs bool is equal to True
        }
    }

}
