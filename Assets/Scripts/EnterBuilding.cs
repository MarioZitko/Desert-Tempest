using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuilding : MonoBehaviour
{
    public GameObject pyramid;
    public GameObject pyramidInterior;

    void OnTriggerEnter2D(Collider2D other){

        if (other.name == "Player"){
            if (pyramid.activeSelf){

                pyramid.SetActive(false);
                pyramidInterior.SetActive(true);
            }

            else{

                pyramid.SetActive(true);
                pyramidInterior.SetActive(false);
            }
    }   
    }

}
