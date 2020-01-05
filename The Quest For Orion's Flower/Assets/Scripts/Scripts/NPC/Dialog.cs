using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxDad; // GameObject for Dad NPC Dialog Box
    public GameObject DialogBoxMum; // GameObject for Mum NPC Dialog Box

    //Dad Text Boxes
    public GameObject DailogTextSword; // GameObject for Dad NPC Sword Dialog
    public GameObject DailogTextQuest; // GameObject for Dad NPC Quest Dialog
    public GameObject DailogDadWin; // GameObject for Dad NPC Game Win Dialog

    // Mum Text Boxes
    public GameObject DailogMumQuest; // GameObject for Mum NPC Quest Dialog
    public GameObject DailogMumWin; // GameObject for Mum NPC Game Win Dialog

    // Start is called before the first frame update
    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DailogTextSword.SetActive(true); // Dad NPC Sword Dialog is equal to True
        DailogMumQuest.SetActive(true); // Mum NPC Quest Dialog is equal to True

        DialogBoxDad.SetActive(false); // Dad NPC Dialog Box is equal to False
        DialogBoxMum.SetActive(false); // Mum NPC Dialog Box is equal to False
        DailogMumWin.SetActive(false); // Mum NPC Win Dialog Box is equal to False
        DailogDadWin.SetActive(false); // Dad NPC Win Dialog Box is equal to False
        DailogTextQuest.SetActive(false); // Dad NPC Quest Dialog Box is equal to False
        #endregion
    }

    private void Update()
    {
        #region Allow Player to deactivate Dialog Box if they are active in the game
        if (DialogBoxMum.activeInHierarchy && Input.GetKeyDown(KeyCode.Space)) // If Mum's Dialog Box is Open, Press Space to close Mum's Dialog Box
        {
            DialogBoxMum.SetActive(false);
        }
        else if (DialogBoxDad.activeInHierarchy && Input.GetKeyDown(KeyCode.Space)) // If Dad's Dialog Box is Open, Press Space to close Dad's Dialog Box
        {
            DialogBoxDad.SetActive(false);
        }
        #endregion

        #region Deactivate other NPC Dialog Box is Player triggers other NPC Dialog Box
        if (DialogBoxDad.activeInHierarchy)
        {
            DialogBoxMum.SetActive(false); // If Dad's Dialog Box is Open, Close Mum's Dialog Box
        }
        else if (DialogBoxMum.activeInHierarchy)
        {
            DialogBoxDad.SetActive(false); // If Mum's Dialog Box is Open, Close Dad's Dialog Box
        }
        #endregion

        #region NPC Dialog Box Changes when Player Acquires Weapons, and Orion's Flower
        if (KeyPickup.SwordPickup == true) // If Player picks up Sword, Change Dialog Options on NPCs
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
        #endregion
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        #region Triggers for NPC Dialog Boxes
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
        #endregion
    }
}
