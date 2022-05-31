using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    
    public TextMeshProUGUI coinText;
    public static CoinCounter instance;

    public void setCoins(int coins){

        coinText.text = coins.ToString();
    }

    void Awake()
    {
        instance = this;
    }


}
