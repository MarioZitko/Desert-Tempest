using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    public GameObject player;
    public GameObject UI;


    void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Player"){

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            DontDestroyOnLoad(this.player);
            DontDestroyOnLoad(this.UI);
        }
    }
}
