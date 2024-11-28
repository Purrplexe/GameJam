using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSwing : MonoBehaviour
{
    public float swingSpeed = 2f; // Speed of swinging
    public float swingRange = 90f; // Maximum swing angle

    private float startingAngle;

    void Start()
    {
        startingAngle = transform.eulerAngles.z; // Initial rotation angle
    }

    void Update()
    {
        // Make the chain swing dynamically
        float angle = startingAngle + Mathf.Sin(Time.time * swingSpeed) * swingRange;
        transform.eulerAngles = new Vector3(0, 0, angle); // Apply the rotation
    }
}

