using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;

    // We read grounded state from ThirdPersonMovement
    ThirdPersonMovement movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<ThirdPersonMovement>();
    }

    void Update()
    {
        // Speed (forward/back)
        float speed = 0f;
        if (Input.GetKey(KeyCode.W)) speed = 1f;
        else if (Input.GetKey(KeyCode.S)) speed = -1f;
        anim.SetFloat("Speed", speed);

        // Jump trigger
        if (Input.GetKeyDown(KeyCode.Space) && movement.IsGrounded())
        {
            anim.SetTrigger("Jump");
        }

        // Falling
        anim.SetBool("IsFalling", !movement.IsGrounded());
    }
}

