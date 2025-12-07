using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; 
    public float dashDuration = 0.5f; 

    private CharacterController characterController;
    private float dashTimer;
    private Vector3 dashDirection;

    void Start()
    {
       
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f)
        {
            
            Dash();
        }

        if (dashTimer > 0f)
        {
            
            characterController.Move(dashDirection * dashDistance * Time.deltaTime / dashDuration);

            
            dashTimer -= Time.deltaTime;
        }
    }

    void Dash()
    {
        
        dashDirection = transform.forward;

        
        dashTimer = dashDuration;
    }
}


