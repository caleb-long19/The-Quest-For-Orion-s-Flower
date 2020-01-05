using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertTempleTeleport : MonoBehaviour
{
    public GameObject Teleporter;
    public GameObject Player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space) & collision.gameObject.tag == "Player" && KeyPickup.DesertKey == true)
        {
            Player.transform.position = new Vector2(Teleporter.transform.position.x, Teleporter.transform.position.y); // If Player Collides with Desert Temple and has Collected all Orbs, Teleport Player
        }
    }
}
