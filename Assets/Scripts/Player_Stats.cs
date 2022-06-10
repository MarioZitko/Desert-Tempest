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
    public static int coins = 0;
    public int hpPots = 0;
    public int stamPots = 0;
    public Animator animator;
    public HealthBar healthBar;
    public StaminaBar staminaBar;
    public GameObject pyramidInterior;
    public ParticleSystem hpPart;
    public ParticleSystem stamPart;
    public TextMeshProUGUI potHpText;
    public TextMeshProUGUI potStamText;

    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        stamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);

        CoinCounter.instance.setCoins(coins);
        
        potStamText.text = stamPots.ToString();
        potHpText.text = hpPots.ToString();

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
            if((coins-mod)<0){
                coins = 0;
            }
            else{
                coins += mod;
            }
        }

        else{coins += mod;}

        CoinCounter.instance.setCoins(coins);
        
    }

    public void setCoins(int setc){

        coins = setc;
        CoinCounter.instance.setCoins(coins);
    }

    public int getCoins(){

        return coins;
    }

    public void useHPpot(){

        if (pyramidInterior == null){
            if (hpPots>=1){

                UpdateHealth(100f);
                hpPots -= 1;
                hpPart.Play();
            }

            potHpText.text = hpPots.ToString();

        }

        else{

        if (pyramidInterior.activeSelf){
            if (coins>=1){
                updateGold(-1);
                hpPots += 1;
            }
        }

        else {

            if (hpPots>=1){

                UpdateHealth(100f);
                hpPots -= 1;
                hpPart.Play();
            }
            
        }
        
        potHpText.text = hpPots.ToString();
        }
    }


    public void useStamPot(){

        if (pyramidInterior == null){


            if (stamPots>=1){

                UpdateStamina(100f);
                stamPots -= 1;
                stamPart.Play();
            }

            potStamText.text = stamPots.ToString();
        }

        else{

        if (pyramidInterior.activeSelf){

            if (coins>=1){
                updateGold(-1);
                stamPots += 1;
            }
        }

        else {

            if (stamPots>=1){

                UpdateStamina(100f);
                stamPots -= 1;
                stamPart.Play();
            }
            
        }
        
        potStamText.text = stamPots.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
