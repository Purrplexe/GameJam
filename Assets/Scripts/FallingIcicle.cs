using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIcicle : MonoBehaviour
{
    public Rigidbody2D icicleRb; // Reference to the icicle's Rigidbody2D

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Check if the player enters the trigger
        {
            icicleRb.bodyType = RigidbodyType2D.Dynamic; // Make the icicle fall
        }
    }
}

