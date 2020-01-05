using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject DialogBoxDad;
    public GameObject DialogBoxMum;

    public GameObject DailogTextSword;
    public GameObject DailogTextQuest;
    public GameObject DailogMumQuest;
    public GameObject DailogDadWin;
    public GameObject DailogMumWin;

    // Start is called before the first frame update
    void Start()
    {
        DialogBoxDad.SetActive(false);
        DialogBoxMum.SetActive(false);
    }

    private void Update()
    {
        if(DialogBoxMum.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            DialogBoxMum.SetActive(false);
        }
        else if (DialogBoxDad.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            DialogBoxDad.SetActive(false);
        }

        if (DialogBoxDad.activeInHierarchy)
        {
            DialogBoxMum.SetActive(false);
        }
        else if (DialogBoxMum.activeInHierarchy)
        {
            DialogBoxDad.SetActive(false);
        }

        if(KeyPickup.SwordPickup == true)
        {
            DailogTextQuest.SetActive(true);
            DailogMumQuest.SetActive(true);
            DailogTextSword.SetActive(false);
        }
        else if (KeyPickup.SwordPickup == false)
        {
            DailogTextSword.SetActive(true);
            DailogMumQuest.SetActive(true);
            DailogTextQuest.SetActive(false);
        }

        if(KeyPickup.OrionFlower == true)
        {
            DailogTextQuest.SetActive(false);
            DailogMumQuest.SetActive(false);
            DailogTextSword.SetActive(false);
            DailogDadWin.SetActive(true);
            DailogMumWin.SetActive(true);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DadNPC")
        {
            Debug.Log("Collided");
            DialogBoxDad.SetActive(true);
        }

        if (collision.tag == "MumNPC")
        {
            Debug.Log("Collided");
            DialogBoxMum.SetActive(true);
        }
    }
}
