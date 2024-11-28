using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGift : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Gift collected!");
            Destroy(gameObject); // Remove gift
        }
    }
}
