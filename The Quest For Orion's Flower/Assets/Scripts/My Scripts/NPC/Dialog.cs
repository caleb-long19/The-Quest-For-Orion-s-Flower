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

        if(PlayerAttack.SwordPickup == true)
        {
            DailogTextQuest.SetActive(true);
            DailogTextSword.SetActive(false);
        }
        else if (PlayerAttack.SwordPickup == false)
        {
            DailogTextSword.SetActive(true);
            DailogTextQuest.SetActive(false);

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
