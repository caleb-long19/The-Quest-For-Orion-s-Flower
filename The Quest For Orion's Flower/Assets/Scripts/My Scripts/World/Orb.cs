using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameObject MagicOrb;
    public GameObject TempleBoss;

    private void Start()
    {
        if (TempleBoss != null)
        {
            MagicOrb.SetActive(false);
        }
    }

    private void Update()
    {
        if (TempleBoss == null)
        {
            Debug.Log("Slime King Is Dead!");
            MagicOrb.SetActive(true);
        }
    }
}
