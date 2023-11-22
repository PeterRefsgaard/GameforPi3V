using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
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
        float newx = startPosition.x + Mathf.Sin(Time.time * speed) * amplitude;

        // Update the object's position with the new Y coordinate
        transform.position = new Vector3(newx, transform.position.y, transform.position.z);
    }
}
