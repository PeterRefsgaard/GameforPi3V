using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float fallSpeed = 5f;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnObjectsRandomly());
    }

    IEnumerator SpawnObjectsRandomly()
    {
        while (true)
        {
            Vector3 spawnPosition = transform.position + new Vector3(8, 5, 0);
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();
            rb.velocity = Vector3.down * fallSpeed;

            yield return new WaitForSeconds(0.1f); // Add a short delay to ensure the object is spawned before checking collisions

            // Check for collisions with the ground or any other surface
            Collider objectCollider = spawnedObject.GetComponent<Collider>();
            if (Physics.Raycast(spawnedObject.transform.position, Vector3.down, out RaycastHit hit, objectCollider.bounds.extents.y))
            {
                // Stop falling if the object hits a surface
                rb.velocity = Vector3.zero;
            }

            float nextSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(nextSpawnInterval);
        }
    }
}









