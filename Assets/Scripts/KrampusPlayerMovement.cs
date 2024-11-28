using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    public Rigidbody2D rb;

    private Vector2 movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chain"))
        {
            // Reduce spirit bar
            Debug.Log("Hit by chain!");
        }
    }


    void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D)
        movement.x = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Move the player
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
}
