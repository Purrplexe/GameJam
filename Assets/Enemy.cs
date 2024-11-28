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
    public float minusPos;
    public float plusPos;
    public LineRenderer lineOfSightSight;
    public Gradient redColor;
    public Gradient greenColor;

    public bool isFacingRight = true;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        gotchaText.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        horizontalMrX = -1f;
    }
    private void Update()
    {
        RaycastHit2D hitInfo;
        if (!isFacingRight)
        {
             hitInfo = Physics2D.Raycast(transform.position, transform.right, lineOfSightDist);
        } else
        {
            hitInfo = Physics2D.Raycast(transform.position, transform.right*-1, lineOfSightDist);
        }
        
        if(hitInfo.collider != null)
        {
            lineOfSightSight.colorGradient = redColor;
            lineOfSightSight.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player Spotted");
                //transform.position = hitInfo.point;
            }
        }
        else
        {
            lineOfSightSight.colorGradient = greenColor;
            lineOfSightSight.SetPosition(1, transform.position + -horizontalMrX * lineOfSightDist * transform.right);
        }
        if (transform.position.x < minusPos)
        {
            horizontalMrX = 1f;

        }
        else if (transform.position.x > plusPos)
        {
            horizontalMrX = -1f;
        }
        lineOfSightSight.SetPosition(0, transform.position);
        Flip();
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
    private void Flip()
    {
        if (isFacingRight && horizontalMrX < 0f || !isFacingRight && horizontalMrX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            //lineOfSightSight.SetPosition(1, transform.position);
        }
    }
}
