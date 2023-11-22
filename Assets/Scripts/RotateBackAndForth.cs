using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackAndForth : MonoBehaviour
{
    public float rotationSpeed = 30f;  // Adjust the speed of rotation
    public float rotationRange = 90f;  // Adjust the range of rotation (from -90 to 90 degrees)

    private float initialRotation;

    void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        // Calculate the rotation angle using Mathf.PingPong to create a back-and-forth effect
        float angle = Mathf.PingPong(Time.time * rotationSpeed, rotationRange) - 90f + initialRotation;

        // Rotate the object around its Z-axis
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}


