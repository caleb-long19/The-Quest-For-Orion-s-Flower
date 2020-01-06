using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTempleTeleport : MonoBehaviour
{
    public GameObject Teleporter; // GameObject for Teleporter Location
    public GameObject Player; // GameObject for Player

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space) & collision.gameObject.tag == "Player" && KeyPickup.ForestKey == true)
        {
            // If Player Collides with Forest Temple and has Collected all Orbs, Teleport Player to Teleported GameObject Location
            Player.transform.position = new Vector2(Teleporter.transform.position.x, Teleporter.transform.position.y);
        }
    }
}
