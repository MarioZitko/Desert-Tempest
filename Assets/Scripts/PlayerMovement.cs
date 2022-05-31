using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public CharacterController2D controller;
    public Animator animator;
    public Player_Stats playerStats;

    public Joystick joystick;

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    float horizontalMove = 0f;
    public int jumpStamina = 10;

    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    }

    public void onLanding(){

        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate(){

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}

