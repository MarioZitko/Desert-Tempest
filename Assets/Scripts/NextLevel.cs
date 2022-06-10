using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    public GameObject player;
    public Player_Stats playerStats;
    public GameObject UI;


    void Start(){

        int PlayerCoins = PlayerPrefs.GetInt("PlayerCoins", 0);
        player.GetComponent<Player_Stats>().setCoins(PlayerCoins);
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Player"){

            PlayerPrefs.SetInt("PlayerCoins", player.GetComponent<Player_Stats>().getCoins());
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            DontDestroyOnLoad(this.player);
            DontDestroyOnLoad(this.UI);
        }
    }
}
