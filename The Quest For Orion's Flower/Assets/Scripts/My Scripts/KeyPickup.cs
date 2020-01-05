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

    public static bool AllOrbs;

    public void Start()
    {
        ForestKey = false;
        FrostKey = false;
        DesertKey = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ForestKey"))
        {
            ForestKey = true;
            Destroy(GameObject.FindWithTag("ForestKey"));
        }
        if (collision.gameObject.tag.Equals("FrostKey"))
        {
            FrostKey = true;
            Destroy(GameObject.FindWithTag("FrostKey"));
        }
        if (collision.gameObject.tag.Equals("DesertKey"))
        {
            DesertKey = true;
            Destroy(GameObject.FindWithTag("DesertKey"));
        }


        if (collision.gameObject.tag.Equals("ForestOrb"))
        {
            ForestOrb = true;
            Destroy(GameObject.FindWithTag("ForestOrb"));
        }
        if (collision.gameObject.tag.Equals("FrostOrb"))
        {
            FrostOrb = true;
            Destroy(GameObject.FindWithTag("FrostOrb"));
        }
        if (collision.gameObject.tag.Equals("DesertOrb"))
        {
            DesertOrb = true;
            Destroy(GameObject.FindWithTag("DesertOrb"));
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
