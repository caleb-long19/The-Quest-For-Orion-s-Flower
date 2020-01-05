using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    private float timeBtwAttack; // the time between a player can attack again
    public float startTimeBtwAttack; // how much time between attacks
    public static bool SwordPickup;

    public Transform PlayerMelee; // the attack position
    public LayerMask whatIsEnemies; // what is an enemy layer mask.
    public Animator playerAnim; // gets Animator component

    public float attackDistanceX; // the range of an attack on the x-axis
    public float attackDistanceY; // the range of an attack on the y-axis

    public static int damage = 10; // the damage of an attack

    private void Start()
    {
        SwordPickup = false;
    }

    void Update()
    {
        if (SwordPickup == true)
        {
            if (timeBtwAttack <= 0)
                {
                    //then the player can attack
                    if (Input.GetKey(KeyCode.Mouse0)) 
                    { // when the player uses left click, the player will punch or swing.
                        playerAnim.SetTrigger("attack"); // animation is set to the attack parameter.
                        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(PlayerMelee.position, new Vector2(attackDistanceX, attackDistanceY), 0, whatIsEnemies); // attack an enemy if it is within that range and has the what is enemy tag.
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                            enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage); // Find Enemy component and deal damage

                    timeBtwAttack = startTimeBtwAttack;
                    }
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword")
        {
            SwordPickup = true;
            Destroy(GameObject.FindWithTag("Sword"));
        }
    }
}
