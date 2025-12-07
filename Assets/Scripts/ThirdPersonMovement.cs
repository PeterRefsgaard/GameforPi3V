using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Refs")]
    public CharacterController controller;
    public Transform cam;   

    [Header("Movement")]
    public float speed = 6f;
    public float rotationSpeed = 360f;   

    [Header("Jump / Gravity")]
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public bool IsGrounded()
    {
        return isGrounded;
    }


    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D
        float vertical = Input.GetAxisRaw("Vertical");   // W/S

        bool rightMouseHeld = Input.GetMouseButton(1);

       
        if (rightMouseHeld)
        {
            

            
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;
            camForward.y = 0f;
            camRight.y = 0f;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * vertical + camRight * horizontal;

            if (moveDir.sqrMagnitude > 0.01f)
            {
                moveDir.Normalize();
                controller.Move(moveDir * speed * Time.deltaTime);
            }
            
        }
        else
        {
            

            
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                float turnAmount = horizontal * rotationSpeed * Time.deltaTime;
                transform.Rotate(0f, turnAmount, 0f);
            }

            
            if (Mathf.Abs(vertical) > 0.1f)
            {
                Vector3 moveDir = transform.forward * vertical;
                controller.Move(moveDir * speed * Time.deltaTime);
            }
        }

      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        
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

