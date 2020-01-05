using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    public int damage;
    public float resetTime = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        GetComponent<Collider2D>().enabled = false;
        Invoke("ResetTrigger", resetTime);
    }

    private void ResetTrigger()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
