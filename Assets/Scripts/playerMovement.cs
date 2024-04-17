using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump =false;
    bool crouch = false;

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {   //move the character
        controller.Move(horizontalMove* Time.fixedDeltaTime, crouch, jump); //no crouch=False no jumping=False
        jump = false;
    }

}