using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public delegate void SendAmmo(int theAmmo);
    public static event SendAmmo OnSendAmmo;

    public new AudioClip audio;

    public static int ammo = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Player")) //If "Player" collides with coin add 20 points and destroy object
        {
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);
            ammo += 5; // Every coin pickup equals to 20 points
            Debug.Log("Player Has Collided!");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (OnSendAmmo != null)
        {
            OnSendAmmo(ammo);
        }
    }
}
