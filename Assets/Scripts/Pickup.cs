using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    public enum PickupObject{COIN, HP, STAMINA};
    public PickupObject currentObject;
    public Player_Stats playerStats;

    void OnTriggerEnter2D(Collider2D other){

        if (other.name == "Player"){

            if (currentObject == PickupObject.COIN){

                playerStats.updateGold(1);
                
            }

            Destroy(gameObject);
        }
    }
} 
