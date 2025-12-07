using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 startingPosition;
    private CharacterController characterController;

    void Start()
    {
        
        startingPosition = transform.position;

        
        characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("RespawnTrigger"))
        {
            
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        Debug.Log("Respawning player.");

        
        characterController.enabled = false;
        characterController.transform.position = startingPosition;
        characterController.enabled = true;

        
        Debug.Log("Player respawned at: " + transform.position);

        
    }
}




