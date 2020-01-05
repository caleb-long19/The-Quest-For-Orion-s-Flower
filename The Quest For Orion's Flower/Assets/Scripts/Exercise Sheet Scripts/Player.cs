using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    private Animator gunAnim;

    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GetComponent<Animator>().SetBool("isFiring", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
    }

    public void SendHealthData(int health)
    {
       
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}

