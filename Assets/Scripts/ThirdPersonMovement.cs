using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Refs")]
    public CharacterController controller;
    public Transform cam;   // not used for movement now, but you can keep it

    [Header("Movement")]
    public float speed = 6f;
    public float rotationSpeed = 360f;   // degrees per second

    [Header("Jump / Gravity")]
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // --- Ground check ---
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // --- Input ---
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D -> rotation
        float vertical = Input.GetAxisRaw("Vertical");   // W/S -> forward/back

        // --- Rotation (A/D) ---
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            // rotate around Y axis
            float turnAmount = horizontal * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, turnAmount, 0f);
        }

        // --- Forward/back movement (W/S) ---
        Vector3 moveDir = transform.forward * vertical;

        if (Mathf.Abs(vertical) > 0.1f)
        {
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        // --- Jump (Space) ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- Gravity ---
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
