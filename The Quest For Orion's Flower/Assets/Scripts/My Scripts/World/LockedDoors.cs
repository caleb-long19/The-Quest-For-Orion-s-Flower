using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoors : MonoBehaviour
{
    public GameObject LockedDoor;
    public GameObject OpenDoor;
    public GameObject GoldKey;
    public AudioClip Key;

    // Start is called before the first frame update
    void Start()
    {
        LockedDoor.SetActive(true); // LockedDoor bool is equal to True
        OpenDoor.SetActive(false); // OpenDoor bool is equal to False
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) // If Player Collides with Golden Key, Open Locked Door
        {
            LockedDoor.SetActive(false); // Locked Door GameObject is set to Inactive
            OpenDoor.SetActive(true); // Open Door GameObject is set to Active
            GoldKey.SetActive(false); // Gold Key GameObject is set to Inactive

            AudioSource.PlayClipAtPoint(Key, this.gameObject.transform.position); // Play Sound Effect
        }
    }
}
