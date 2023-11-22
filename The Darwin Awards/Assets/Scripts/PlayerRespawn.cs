using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startingPosition;
    private CharacterController characterController;

    void Start()
    {
        // Save the starting position when the game starts
        startingPosition = transform.position;

        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a tag to identify it as the trigger object
        if (other.CompareTag("RespawnTrigger"))
        {
            // Respawn the player at the starting position
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        Debug.Log("Respawning player.");

        // Stop the player's movement
        characterController.enabled = false;
        characterController.transform.position = startingPosition;
        characterController.enabled = true;

        // Additional debug log to check if the method is being called
        Debug.Log("Player respawned at: " + transform.position);

        // You can add additional actions here, like resetting health, etc.
    }
}




