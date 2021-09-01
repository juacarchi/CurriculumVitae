using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D rigidBody2D;

    float horizontalMove = 0f;
    public float runSpeed = 40f;

    bool jump = false;
    bool sprint = false;

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.GetCanMove())
        {
            if (controller.canJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    SFXManager.instance.PlaySFX(SFXManager.instance.jump);
                }
            }

            if (Input.GetButtonDown("Shift"))
            {
                sprint = true;
            }

            if (Input.GetButtonUp("Shift"))
            {
                sprint = false;
            }

            if (sprint)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * (runSpeed * 2);
            }
            else
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            }
        }
        else
        {
            horizontalMove = 0;        }
            
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

}

