using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject player;
    public GameObject thirdPersonMovement;
    public Camera mainCamera;

    private bool isThirdPersonActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TogglePlayerMovement();
            ToggleThirdPersonMovement();
            ToggleCamera();
        }
    }

    void TogglePlayerMovement()
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = !isThirdPersonActive;
        }
    }

    void ToggleThirdPersonMovement()
    {
        ThirdPersonMovement thirdPersonScript = thirdPersonMovement.GetComponent<ThirdPersonMovement>();
        if (thirdPersonScript != null)
        {
            thirdPersonScript.enabled = isThirdPersonActive;
            isThirdPersonActive = !isThirdPersonActive;
        }
    }

    void ToggleCamera()
    {
        mainCamera.enabled = isThirdPersonActive;
    }
}