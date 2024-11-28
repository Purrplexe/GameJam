using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    private PointManager pointManager;

    private void Start()
    {
        // Find and assign the PointManager in the scene
        pointManager = FindObjectOfType<PointManager>();
    }

    private Vector3 _startPosition;
    private bool _isDragging = false;

    private void OnMouseDown()
    {
        _isDragging = true;
        _startPosition = transform.position; // Remember the original position
    }

    private void OnMouseDrag()
    {
        if (_isDragging)
        {
            // Update item position to follow the mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure the item stays on the same plane
            transform.position = mousePosition;
        }
    }

    private void OnMouseUp()
    {
        _isDragging = false;
        CheckPlacement();

        // Check for overlap with a bin
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);

        if (hitCollider != null)
        {
            // Check if the item is placed correctly
            if (hitCollider.CompareTag("GoodBasket") && CompareTag("GoodItem"))
            {
                pointManager.AddPoints(1); // Add points for good placement
                Destroy(gameObject); // Remove the item
            }
            else if (hitCollider.CompareTag("BadBasket") && CompareTag("BadItem"))
            {
                pointManager.AddPoints(1); // Add points for bad placement
                Destroy(gameObject); // Remove the item
            }
            else
            {
                // Incorrect placement, return to start position
                transform.position = _startPosition;
            }
        }
        else
        {
            // No bin hit, return to start position
            transform.position = _startPosition;
        }
    }



    private void CheckPlacement()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);

        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("GoodBasket") && gameObject.CompareTag("GoodItem"))
            {
                Debug.Log("Correct! Good item in the Good Basket.");
                Destroy(gameObject);
                return;
            }
            else if (hit.CompareTag("BadBasket") && gameObject.CompareTag("BadItem"))
            {
                Debug.Log("Correct! Bad item in the Bad Basket.");
                Destroy(gameObject);
                return;
            }
        }

        // If placement is incorrect, return to the starting position
        Debug.Log("Incorrect placement. Try again!");
        transform.position = _startPosition;
    }
}
