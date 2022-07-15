using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){Resume();}
            else {Pause();}
        }
    }
    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Load(){
        SceneManager.LoadScene(0);
    }
}
