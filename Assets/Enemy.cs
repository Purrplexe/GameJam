using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float horizontalMrX;
    public float moveSpeed = 4f;
    private Rigidbody2D rb;
    public float lineOfSightDist;
    public GameObject gotchaText;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        gotchaText.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        horizontalMrX = -1f;
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, lineOfSightDist);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if (hitInfo.collider.CompareTag("Player"))
            {

            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * lineOfSightDist,Color.green);
        }
        if (transform.position.x < -9f)
        {
            horizontalMrX = 1f;

        }
        else if (transform.position.x > 9)
        {
            horizontalMrX = -1f;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMrX * moveSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            gotchaText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            gotchaText.SetActive(false);
        }
    }
}
