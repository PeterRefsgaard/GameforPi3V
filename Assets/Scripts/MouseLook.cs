using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody; // assign your player root
    public float sensitivity = 100f;

    float xRotation = 0f;

    void Update()
    {
        // only rotate while RMB is held
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            // vertical look (camera only)
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // horizontal look (rotate player)
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
