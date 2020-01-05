using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxDad;
    public GameObject DialogBoxMum;

    //Dad Text Boxes
    public GameObject DailogTextSword;
    public GameObject DailogTextQuest;
    public GameObject DailogDadWin;

    // Mum Text Boxes
    public GameObject DailogMumQuest;
    public GameObject DailogMumWin;

    // Start is called before the first frame update
    void Start()
    {
        DialogBoxDad.SetActive(false);
        DialogBoxMum.SetActive(false);
        DailogTextSword.SetActive(true);
        DailogMumQuest.SetActive(true);
        DailogMumWin.SetActive(false);
        DailogDadWin.SetActive(false);
        DailogTextQuest.SetActive(false);
    }

    private void Update()
    {
        if(DialogBoxMum.activeInHierarchy && Input.GetKeyDown(KeyCode.Space)) // If Mum's Dialog Box is Open, Press Space to close Mum's Dialog Box
        {
            DialogBoxMum.SetActive(false);
        }
        else if (DialogBoxDad.activeInHierarchy && Input.GetKeyDown(KeyCode.Space)) // If Dad's Dialog Box is Open, Press Space to close Dad's Dialog Box
        {
            DialogBoxDad.SetActive(false);
        }


        if (DialogBoxDad.activeInHierarchy) // If Dad's Dialog Box is Open, Close Mum's Dialog Box
        {
            DialogBoxMum.SetActive(false);
        }
        else if (DialogBoxMum.activeInHierarchy) // If Mum's Dialog Box is Open, Close Dad's Dialog Box
        {
            DialogBoxDad.SetActive(false);
        }


        if(KeyPickup.SwordPickup == true) // If Player picks up Sword, Change Dialog Options on NPCs
        {
            DailogTextQuest.SetActive(true);
            DailogMumQuest.SetActive(true);
            DailogTextSword.SetActive(false);
        }
        else if (KeyPickup.SwordPickup == false) // If Player doesn't pick up Sword, Change Dialog Options on NPCs
        {
            DailogTextSword.SetActive(true);
            DailogMumQuest.SetActive(true);
            DailogTextQuest.SetActive(false);
        }

        if(KeyPickup.OrionFlower == true) // If Player picks up Orion's Flower, Change Dialog Options on NPCs
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
            DialogBoxDad.SetActive(true); // Display Dad's Dialog Box when Player Collides with Dad NPC
        }

        if (collision.tag == "MumNPC")
        {
            Debug.Log("Collided"); 
            DialogBoxMum.SetActive(true); // Display Mum's Dialog Box when Player Collides with Mum NPC
        }
    }
}
