using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    public float amplitude = 1f;  
    public float speed = 2f;      

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * amplitude;

        
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
