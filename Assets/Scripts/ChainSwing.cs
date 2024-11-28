using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSwing : MonoBehaviour
{
    public float swingSpeed = 2f; // Speed of swinging
    public float swingRange = 90f; // Maximum swing angle

    private SpiritManager spiritManager; // Reference to SpiritManager
    private float startingAngle;

    void Start()
    {
        // Find the SpiritManager in the scene
        spiritManager = FindObjectOfType<SpiritManager>();
        if (spiritManager == null)
        {
            Debug.LogError("SpiritManager not found in the scene!");
        }

        startingAngle = transform.eulerAngles.z; // Initial rotation angle
    }

    void Update()
    {
        // Make the chain swing dynamically
        float angle = startingAngle + Mathf.Sin(Time.time * swingSpeed) * swingRange;
        transform.eulerAngles = new Vector3(0, 0, angle); // Apply the rotation
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Changed to Player tag
        {
            if (spiritManager != null)
            {
                spiritManager.SubtractSpirit(20f); // Subtract spirit points
            }
            else
            {
                Debug.LogWarning("SpiritManager is missing!");
            }
        }
    }
}


