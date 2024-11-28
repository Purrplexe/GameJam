using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGift : MonoBehaviour
{
    private SpiritManager spiritManager;

    private void Start()
    {
        // Find the SpiritManager in the scene
        spiritManager = FindObjectOfType<SpiritManager>();
        if (spiritManager == null)
        {
            Debug.LogError("SpiritManager not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Gift collected!");
            if (spiritManager != null)
            {
                spiritManager.AddSpirit(10f); // Add spirit points
                spiritManager.CollectGift(); // Increment gift count
            }
            Destroy(gameObject); // Remove the gift
        }
    }
}
