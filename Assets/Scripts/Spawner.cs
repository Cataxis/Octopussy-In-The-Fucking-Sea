using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> trashObjects;
    [SerializeField] float maxX;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float initialSpawnRate;
    [SerializeField] float spawnRateDecrease;
    [SerializeField] float minSpawnRate;

    private float currentSpawnRate;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        StartSpawning();
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnTrash", 0.5f, currentSpawnRate);
    }

    private void SpawnTrash()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        int randomIndex = Random.Range(0, trashObjects.Count);
        GameObject trashObject = trashObjects[randomIndex];

        Instantiate(trashObject, spawnPos, Quaternion.identity);

        // Gradually decrease spawn rate
        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate -= spawnRateDecrease;
            if (currentSpawnRate < minSpawnRate)
            {
                currentSpawnRate = minSpawnRate;
            }

            // Cancel the previous InvokeRepeating and start a new one with the updated spawn rate
            CancelInvoke("SpawnTrash");
            InvokeRepeating("SpawnTrash", currentSpawnRate, currentSpawnRate);
        }
    }
}
