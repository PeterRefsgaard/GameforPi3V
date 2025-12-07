using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject particleEffectPrefab; 

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.collider.CompareTag("SpawnedObjectTag"))
        {
            
            Instantiate(particleEffectPrefab, hit.transform.position, Quaternion.identity);

            
            Debug.Log("Player collided with a spawned object!");

            
            Destroy(hit.gameObject);
        }

        if (hit.collider.CompareTag("WinFlag"))
        {
            
                SceneManager.LoadScene(2);
                
        }
    }
}


