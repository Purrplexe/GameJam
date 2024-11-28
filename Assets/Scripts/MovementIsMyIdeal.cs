using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class MovementIsMyIdeal : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower = 8f;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Camera Cam;
    Vector2 mousePos;
    private Transform aimTransform;
    public Transform weapon;
    public float offSet;
    public Transform shootingPoint;
    public GameObject bullet;
    public float timeBetweenShots;
    private float prevShotTime;
    //public Weapon currentWeapon;

    public int maxHealth;
    public int currentHealth;

    private float horizontal;
    public bool isFacingRight = true;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public SpriteRenderer rend;
    public bool canHide = false;
    public bool hiding = false;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(canHide && Input.GetKey("f"))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            rend.sortingOrder = -1;
            hiding = true;
            Debug.Log("f in the chat");
        }
        else
        {
            Physics2D.IgnoreLayerCollision(7, 8, false);
            rend.sortingOrder = 2;
            hiding = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (Time.time >= prevShotTime + timeBetweenShots)
            {
                prevShotTime = Time.time;
                Debug.Log("shot");
                //currentWeapon.Shoot();
                //nextShotTime = Time.time + 1 / currentWeapon.fireRate;
            }
        }
        ProccessInputs();
        /*  mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
          Vector2 lookDir = mousePos - rb.position;
          float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
          rb.rotation = angle;
          //aimTransform.eulerAngles = new Vector3(0, 0, angle);
          /*Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
          diff.Normalize();
          float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
          transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);*/

        /*Vector3 mousePosition = PlayerAimGun.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);*/

    }
    /*void FixedUpdate()
    {
        //Move();
        
    }*/

    private void FixedUpdate()
    {
        if (!hiding)
        {
            //rb.velocity = new Vector2(horizontal,rb.velocity.y);
            
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("HidingSpot"))
        {
            canHide = true;
            Debug.Log("In");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("HidingSpot"))
        {
            canHide = false;
            Debug.Log("Out");
        }
    }
    void ProccessInputs()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * moveSpeed * Time.deltaTime;

        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + offSet);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        Flip();
        /* if(Input.GetMouseButtonDown(0))
         {
             if(Time.time > nextShotTime)
             {
                 nextShotTime = Time.time + timeBetweenShots;
                 Instantiate(bullet, shootingPoint.position, shootingPoint.rotation);
             }
         }
         /* float moveX = Input.GetAxisRaw("Horizontal");
          float moveY = Input.GetAxisRaw("Vertical");
          moveDirection = new Vector2(moveX,moveY);*/
    }
    public void PlayerTakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    /*void Move()

    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }*/

}
