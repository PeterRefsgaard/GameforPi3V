using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
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
        
        float newx = startPosition.x + Mathf.Sin(Time.time * speed) * amplitude;

        
        transform.position = new Vector3(newx, transform.position.y, transform.position.z);
    }
}
