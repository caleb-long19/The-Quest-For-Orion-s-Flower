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
        LockedDoor.SetActive(true);
        OpenDoor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            LockedDoor.SetActive(false);
            OpenDoor.SetActive(true);
            GoldKey.SetActive(false);
            AudioSource.PlayClipAtPoint(Key, this.gameObject.transform.position);
        }
    }
}
