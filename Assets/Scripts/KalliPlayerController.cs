using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalliPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject tranquilizerPrefab; // Drag tranquilizer projectile prefab here
    public Transform firePoint; // Empty GameObject at player's "gun"

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Movement Input
        movement.x = Input.GetAxis("Horizontal");

        // Shoot Tranquilizer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootTranquilizer();
        }

        // Calm Goblin (if close)
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryCalmGoblin();
        }
    }

    private void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    private void ShootTranquilizer()
    {
        // Instantiate tranquilizer at firePoint's position
        Instantiate(tranquilizerPrefab, firePoint.position, Quaternion.identity);
    }

    private void TryCalmGoblin()
    {
        // Detect nearby goblin
        Collider2D[] hitGoblins = Physics2D.OverlapCircleAll(transform.position, 1.5f); // Small range around the player

        foreach (var goblin in hitGoblins)
        {
            if (goblin.CompareTag("Goblin"))
            {
                goblin.GetComponent<GoblinBehavior>().CalmGoblin();
                break;
            }
        }
    }
}

