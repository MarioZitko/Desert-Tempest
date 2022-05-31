using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_Stats : MonoBehaviour
{
    float health = 0f;
    public float maxHealth = 100f;
    float stamina = 0f;
    public float maxStamina = 100f;
    public int coins = 0;
    public Animator animator;
    public HealthBar healthBar;
    public StaminaBar staminaBar;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        stamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);

    }

    public void UpdateHealth(float mod){

        if (mod<0){
            
                animator.SetTrigger("Hurt");
                UpdateStamina(mod/2);
            
            }

        health += mod;

        if (health > maxHealth){

            health = maxHealth;
        }

        else if (health <= 0){
            
            health = 0f;
            animator.SetBool("Death", true);
            
        }

        healthBar.setHealth(health);
    }

    public void UpdateStamina(float mod){

        if (mod<0){}
        stamina += mod;

        if (stamina > maxStamina){

            stamina = maxStamina;
        }

        else if (stamina <= 0){
            
            stamina = 0f;
            
        }

        staminaBar.setStamina(stamina);
    }

    public bool CheckStamina(int cost){

        if (cost>stamina){
            return false;
        }

        else if (cost <= stamina){

            return true;
        }

        return false;
    }

    public void updateGold(int mod){

        if (mod<0){
        if((coins-mod)<0){coins = 0;}}
        else{coins += mod;}

        CoinCounter.instance.setCoins(coins);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
