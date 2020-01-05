using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    public int damage;
    public float resetTime = 0.25f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SendMessage("TakeEnemyDamage", damage, SendMessageOptions.DontRequireReceiver);
        GetComponent<Collider2D>().enabled = false;
        Invoke("ResetCollision", resetTime);
    }

    private void ResetCollision()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
