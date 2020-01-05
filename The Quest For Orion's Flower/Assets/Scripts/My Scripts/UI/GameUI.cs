using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    //Integers
    public int currentHealth; // Int variable called currentHealth
    public int currentShield; // Int variable called currentHealth
    public int currentAmmo; // Int variable called currentHealth

    //Unity References
    public Slider healthBar;
    public Slider shieldBar;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;

    //Unity GameObject References
    public GameObject SwordIcon;
    public GameObject BowIcon;

    public GameObject ForestOrb;
    public GameObject FrostOrb;
    public GameObject DesertOrb;

    public void Update()
    {
        currentHealth = HealthSystem.health;  // currentHealth is equal to health
        currentShield = HealthSystem.shield; // currentShield is equal to shield
        currentAmmo = Ammo.ammo; // currentAmmo is equal to ammo

        healthBar.value = currentHealth; // Health Bar Slider is equal to Integer Health
        shieldBar.value = currentShield; // Shield Bar Slider is equal to Integer Shield
        ammoText.text = "AMMO: " + currentAmmo.ToString(); // Ammo Counter Text is equal to Integer Ammo
        scoreText.text = "SCORE: " + Coin.score.ToString(); // Score Counter Text is equal to Integer Score

        // Player Weapon IF Statements
        if(KeyPickup.SwordPickup == true)
        {
            Color tmp = SwordIcon.GetComponent<SpriteRenderer>().color;
            tmp.a = 100f;
            SwordIcon.GetComponent<SpriteRenderer>().color = tmp;
        }

        if (KeyPickup.BowPickup == true)
        {
            Color tmp = BowIcon.GetComponent<SpriteRenderer>().color;
            tmp.a = 100f;
            BowIcon.GetComponent<SpriteRenderer>().color = tmp;
        }

        // Temple Orbs IF Statements
        if (KeyPickup.ForestOrb == true)
        {
            Color tmp = ForestOrb.GetComponent<SpriteRenderer>().color;
            tmp.a = 100f;
            ForestOrb.GetComponent<SpriteRenderer>().color = tmp;
        }

        if (KeyPickup.FrostOrb == true)
        {
            Color tmp = FrostOrb.GetComponent<SpriteRenderer>().color;
            tmp.a = 100f;
            FrostOrb.GetComponent<SpriteRenderer>().color = tmp;
        }

        if (KeyPickup.DesertOrb == true)
        {
            Color tmp = DesertOrb.GetComponent<SpriteRenderer>().color;
            tmp.a = 100f;
            DesertOrb.GetComponent<SpriteRenderer>().color = tmp;
        }
    }
}