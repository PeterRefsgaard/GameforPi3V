using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("Jump");

        // Forward/back via Speed
        if (Input.GetKey(KeyCode.W))
            anim.SetFloat("Speed", 1f);
        else if (Input.GetKey(KeyCode.S))
            anim.SetFloat("Speed", -1f);
        else
            anim.SetFloat("Speed", 0f);
    }
}
