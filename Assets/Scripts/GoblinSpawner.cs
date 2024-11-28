using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    public GameObject goblinPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnGoblin), 1f, spawnInterval);
    }

    private void SpawnGoblin()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(goblinPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
