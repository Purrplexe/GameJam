using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs (coin and coal)
    public Transform[] spawnPoints; // Array of spawn point transforms
    public float spawnInterval = 2f; // Time between spawns

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 1f, spawnInterval); // Repeatedly spawn items
    }

    private void SpawnItem()
    {
        if (spawnPoints.Length == 0 || itemPrefabs.Length == 0) return;

        // Find a random spawn point
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];

        // Check if the spawn point is clear
        Collider2D overlapCheck = Physics2D.OverlapPoint(spawnPoint.position);

        if (overlapCheck == null) // Spawn only if the point is clear
        {
            // Choose a random item prefab and spawn it
            int randomItemIndex = Random.Range(0, itemPrefabs.Length);
            GameObject spawnedItem = Instantiate(
                itemPrefabs[randomItemIndex],
                spawnPoint.position,
                Quaternion.identity
            );

            // Ensure the spawned item has the DraggableItem script
            if (!spawnedItem.GetComponent<DraggableItem>())
            {
                spawnedItem.AddComponent<DraggableItem>();
            }
        }
        else
        {
            Debug.Log("Spawn point is occupied, skipping spawn.");
        }
    }

}
