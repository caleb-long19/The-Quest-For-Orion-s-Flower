using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject TempleOrb; // GameObject for Temple Orbs
    public GameObject TempleBoss; // GameObject for Temple Bosses

    private void Start()
    {
        if (TempleBoss != null)
        {
            TempleOrb.SetActive(false); // If Temple Boss isn't dead, Temple Orb GameObject is equal to false
        }
    }

    private void Update()
    {
        if (TempleBoss == null)
        {
            TempleOrb.SetActive(true); // If Temple Boss is dead, Temple Orb GameObject is equal to true

            Debug.Log("Slime King Is Dead!");
        }
    }
}
