using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject particleEffectPrefab; // Reference to your particle effect prefab

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the colliding object has a tag to identify it as a spawned object
        if (hit.collider.CompareTag("SpawnedObjectTag"))
        {
            // Instantiate particle effect at the object's position
            Instantiate(particleEffectPrefab, hit.transform.position, Quaternion.identity);

            // Do something when the player collides with a spawned object
            Debug.Log("Player collided with a spawned object!");

            // Destroy the object
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("WinFlag"))
        {
            
                SceneManager.LoadScene(2);
                
        }
    }
}


