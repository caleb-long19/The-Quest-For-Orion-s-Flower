using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public float fireTime = 0.5f;

    private bool isFiring = false;

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}

