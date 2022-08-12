using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour{

    public CharacterController2D controller;
    public Animator animator;
    public Player_Stats playerStats;
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public Joystick joystick;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    float horizontalMove = 0f;
    public int jumpStamina = 10;
    bool jump = false;
    bool crouch = false;

    void Start()
    {
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (joystick.Horizontal >= .2f && joystick.Horizontal <= .5f){
            horizontalMove = walkSpeed;

        } else if (joystick.Horizontal <= -.2f && joystick.Horizontal >= -.5f){
            horizontalMove = -walkSpeed;
			
        } else if (joystick.Horizontal >= .5f){
            if (playerStats.CheckStamina(1)){
                horizontalMove = runSpeed;
                playerStats.UpdateStamina(-0.01f);
            }
			
        } else if (joystick.Horizontal <= -.5f){
            if (playerStats.CheckStamina(1)){
                horizontalMove = -runSpeed;
                playerStats.UpdateStamina(-0.01f);
            }
			
        }else {
            horizontalMove = 0f;
        }

        float verticalMove = joystick.Vertical;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (verticalMove >= .5f){
            if (playerStats.CheckStamina(jumpStamina)){
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }

        if (verticalMove <= .5f){
            crouch = true;
        } 
        else{
            crouch = false;
        }
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    public void onLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void respawn(){
        SceneManager.LoadScene("Game");
        Destroy (GameObject.Find("Player"));
        Destroy (GameObject.Find("fallDetector"));
        Destroy (GameObject.Find("UI and Camera"));
        transform.position = respawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.name == "fallDetector"){
            respawn();
        }
    }
}

