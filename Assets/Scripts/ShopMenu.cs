using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{

        public GameObject shopMenuUI;
        public GameObject shopBtn;
    
    void start(){

        shopMenuUI.SetActive(false);
    }

    public void openShop(){

        Debug.Log("kurac");
        shopBtn.SetActive(false);
        shopMenuUI.SetActive(true);
    }

    public void closeShop(){

        shopBtn.SetActive(true);
        shopMenuUI.SetActive(false);
    }
}
