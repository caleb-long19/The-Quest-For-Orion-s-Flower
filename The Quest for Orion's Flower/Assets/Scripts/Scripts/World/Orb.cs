using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject TempleOrb;
    public GameObject TempleBoss;

    private void Start()
    {
        if (TempleBoss != null)
        {
            TempleOrb.SetActive(false); // If Temple Boss isn't dead, Temple Orb is equal to false
        }
    }

    private void Update()
    {
        if (TempleBoss == null)
        {
            TempleOrb.SetActive(true); // If Temple Boss is dead, Temple Orb is equal to true
        }
    }
}
