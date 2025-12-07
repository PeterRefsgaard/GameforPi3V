using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackAndForth : MonoBehaviour
{
    public float rotationSpeed = 30f;  
    public float rotationRange = 90f;  

    private float initialRotation;

    void Start()
    {
        
        initialRotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        
        float angle = Mathf.PingPong(Time.time * rotationSpeed, rotationRange) - 90f + initialRotation;

        
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}


