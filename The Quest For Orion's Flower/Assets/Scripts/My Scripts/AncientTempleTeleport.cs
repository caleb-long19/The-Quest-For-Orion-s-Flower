using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncientTempleTeleport : MonoBehaviour
{
    public GameObject Teleporter;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && KeyPickup.AllOrbs == true)
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        Player.transform.position = new Vector2(Teleporter.transform.position.x, Teleporter.transform.position.y);
    }
}
