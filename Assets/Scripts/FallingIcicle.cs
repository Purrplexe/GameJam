using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIcicle : MonoBehaviour
{
    public Rigidbody2D icicleRb; // Reference to the icicle's Rigidbody2D
    private SpiritManager spiritManager; // Reference to SpiritManager
    public float destroyAfterSeconds = 5f; // Time before the icicle disappears

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
        if (collision.CompareTag("Player")) // Check if the player enters the trigger
        {
            icicleRb.bodyType = RigidbodyType2D.Dynamic; // Make the icicle fall
            Destroy(gameObject, destroyAfterSeconds); // Destroy the icicle after the delay
        }
        if (collision.CompareTag("Icicle"))
        {
            if (spiritManager != null)
            {
                spiritManager.SubtractSpirit(20f); // Subtract spirit
            }
        }
    }
}


