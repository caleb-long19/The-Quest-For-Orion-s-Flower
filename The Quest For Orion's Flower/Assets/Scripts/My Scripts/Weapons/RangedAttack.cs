using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    //Bow Variables
    public GameObject arrowPrefab;
    public Transform player;
    public Transform arrowSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    public AudioClip Bow;
    public Rigidbody2D arrow;

    private void Start()
    {
        arrow = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && KeyPickup.BowPickup == true && Ammo.ammo >= 1)
        {
            if (!isFiring)
            {
                Fire();
                Ammo.ammo -= 1;
                AudioSource.PlayClipAtPoint(Bow, this.gameObject.transform.position);
            }
        }
    }

    private void SetFiring()
    {
        isFiring = false;
    }

    private void Fire()
    {
        isFiring = true;
        Instantiate(arrowPrefab, arrowSpawn.position, arrowSpawn.rotation);
        Invoke("SetFiring", fireTime);
    }
}
