using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public delegate void UpdateShield(int newShield);
    public static event UpdateShield OnUpdateShield;

    private Animator gunAnim;

    private void Start()
    {
        gunAnim = GetComponent<Animator>();
    }

    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

    public void SendShieldData(int shield)
    {
        if (OnUpdateShield != null)
        {
            OnUpdateShield(shield);
        }
    }
}

