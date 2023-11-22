using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    public float amplitude = 1f;  // Adjust the height of the movement
    public float speed = 2f;      // Adjust the speed of the movement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine function for oscillation
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        // Update the object's position with the new Y coordinate
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
