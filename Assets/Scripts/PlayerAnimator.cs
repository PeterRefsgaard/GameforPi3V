using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;

    
    ThirdPersonMovement movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<ThirdPersonMovement>();
    }

    void Update()
    {
        
        float speed = 0f;
        if (Input.GetKey(KeyCode.W)) speed = 1f;
        else if (Input.GetKey(KeyCode.S)) speed = -1f;
        anim.SetFloat("Speed", speed);

        
        if (Input.GetKeyDown(KeyCode.Space) && movement.IsGrounded())
        {
            anim.SetTrigger("Jump");
        }

        
        anim.SetBool("IsFalling", !movement.IsGrounded());
    }
}

