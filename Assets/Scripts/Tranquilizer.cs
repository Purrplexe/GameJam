using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranquilizer : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        // Move the tranquilizer forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goblin"))
        {
            collision.GetComponent<GoblinBehavior>().CalmGoblin();
            Destroy(gameObject); // Destroy tranquilizer
        }
        else if (collision.CompareTag("Ground")) // Destroy tranquilizer if it hits the ground
        {
            Destroy(gameObject);
        }
    }
}
