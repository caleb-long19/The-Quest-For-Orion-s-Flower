using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{

    // UI Elements
    public Slider healthBar;
    public Slider shieldBar;
    public Text scoreText;
    public Text ammoText;

    //Integers
    public int playerScore = 0;
    public int playerAmmo = 0;

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        Player.OnUpdateShield += UpdateShield;
        AddScore.OnSendScore += UpdateScore;
        Ammo.OnSendAmmo += UpdateAmmo;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        Player.OnUpdateShield -= UpdateShield;
        AddScore.OnSendScore -= UpdateScore;
        Ammo.OnSendAmmo -= UpdateAmmo;
    }

    public void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateShield(int shield)
    {
        shieldBar.value = shield;
    }

    private void UpdateScore(int theScore)
    {
        playerScore += theScore;
        scoreText.text = "SCORE: " + playerScore.ToString();
    }

    private void UpdateAmmo(int Ammo)
    {
        playerAmmo += Ammo;
        ammoText.text = "AMMO: " + playerAmmo.ToString();
    }
}