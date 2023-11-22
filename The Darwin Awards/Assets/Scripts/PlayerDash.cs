using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // Adjust the dash distance as needed
    public float dashDuration = 0.5f; // Adjust the dash duration as needed

    private CharacterController characterController;
    private float dashTimer;
    private Vector3 dashDirection;

    void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0f)
        {
            // Trigger the dash when the Space key is pressed and not currently dashing
            Dash();
        }

        if (dashTimer > 0f)
        {
            // Move the player in the dash direction
            characterController.Move(dashDirection * dashDistance * Time.deltaTime / dashDuration);

            // Decrease the dash timer
            dashTimer -= Time.deltaTime;
        }
    }

    void Dash()
    {
        // Get the forward direction of the player
        dashDirection = transform.forward;

        // Set the dash timer to the specified duration
        dashTimer = dashDuration;
    }
}


