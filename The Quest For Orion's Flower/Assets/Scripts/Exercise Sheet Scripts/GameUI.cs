using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{

    // UI Elements
    public Slider healthBar;
    public Slider shieldBar;
    public Text scoreText;

    //Integers
    public int playerScore = 0;

    private void OnEnable()
    {
        Player.OnUpdateHealth += UpdateHealthBar;
        Player.OnUpdateShield += UpdateShield;
        AddScore.OnSendScore += UpdateScore;
    }

    private void OnDisable()
    {
        Player.OnUpdateHealth -= UpdateHealthBar;
        Player.OnUpdateShield -= UpdateShield;
        AddScore.OnSendScore -= UpdateScore;
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

}