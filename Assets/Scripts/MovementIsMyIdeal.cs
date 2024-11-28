using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementIsMyIdeal : MonoBehaviour
{
    public float moveSpeed;
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

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    void Update()
    {
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

    void ProccessInputs()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * moveSpeed * Time.deltaTime;

        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0, 0, angle + offSet);

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
    /*void Move()

    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

    }*/

}
