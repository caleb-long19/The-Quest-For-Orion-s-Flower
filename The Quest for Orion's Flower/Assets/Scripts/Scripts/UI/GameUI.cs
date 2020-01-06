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
        #region Health, Shield, and Score UI Elements
        currentHealth = HealthSystem.health;  // currentHealth is equal to health
        currentShield = HealthSystem.shield; // currentShield is equal to shield
        currentAmmo = Ammo.ammo; // currentAmmo is equal to ammo

        healthBar.value = currentHealth; // Health Bar Slider is equal to Integer Health
        shieldBar.value = currentShield; // Shield Bar Slider is equal to Integer Shield
        ammoText.text = "AMMO: " + currentAmmo.ToString(); // Ammo Counter Text is equal to Integer Ammo
        scoreText.text = "SCORE: " + Coin.score.ToString(); // Score Counter Text is equal to Integer Score
        #endregion

        #region Player UI Weapon Icon IF Statements
        if (KeyPickup.SwordPickup == true) // If Sword has been picked up, run method
        {
            Color tmp = SwordIcon.GetComponent<SpriteRenderer>().color; //Get the Sword Icon Game Object
            tmp.a = 100f; // Alpha colour is equal to 100
            SwordIcon.GetComponent<SpriteRenderer>().color = tmp; // Sword Icon Alpha Colour is equal to tmp (100)
        }

        if (KeyPickup.BowPickup == true) // If Bow has been picked up, run method
        {
            Color tmp = BowIcon.GetComponent<SpriteRenderer>().color; // Get the Bow Icon Game Object
            tmp.a = 100f; // Alpha colour is equal to 100
            BowIcon.GetComponent<SpriteRenderer>().color = tmp; // Sword Icon Alpha Colour is equal to tmp (100)
        }
        #endregion

        #region Player UI Temple Orb Icons IF Statements
        if (KeyPickup.ForestOrb == true) // If Player has picked up Forest Orb, run method
        {
            Color tmp = ForestOrb.GetComponent<SpriteRenderer>().color; // Get the Forest Orb Icon Game Object
            tmp.a = 100f; // Alpha colour is equal to 100
            ForestOrb.GetComponent<SpriteRenderer>().color = tmp; // Forest Orb Icon Alpha Colour is equal to tmp (100)
        }

        if (KeyPickup.FrostOrb == true) // If Player has picked up Frost Orb, run method
        {
            Color tmp = FrostOrb.GetComponent<SpriteRenderer>().color; // Get the Frost Orb Icon Game Object
            tmp.a = 100f; // Alpha colour is equal to 100
            FrostOrb.GetComponent<SpriteRenderer>().color = tmp; // Frost Orb Icon Alpha Colour is equal to tmp (100)
        }

        if (KeyPickup.DesertOrb == true) // If Player has picked up Desert Orb, run method
        {
            Color tmp = DesertOrb.GetComponent<SpriteRenderer>().color; // Get the Desert Orb Icon Game Object
            tmp.a = 100f; // Alpha colour is equal to 100
            DesertOrb.GetComponent<SpriteRenderer>().color = tmp; // Desert Orb Icon Alpha Colour is equal to tmp (100)
        }
        #endregion
    }
}