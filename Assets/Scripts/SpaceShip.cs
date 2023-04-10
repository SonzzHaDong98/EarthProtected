using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public AudioClip bulletSound;

    public Bullet bulletPrefab;

    public float pushSpeed;
    public float turnSpeed;

    private bool pushSpaceShip;
    private float turnDirection;
    private bool push = false;
    private bool moveLeft = false;
    private bool moveRight = false;

    private Rigidbody2D rb;
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        pushSpaceShip = Input.GetKey(KeyCode.W);
        if (Input.GetKey(KeyCode.A))
        {
            turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnDirection = -1.0f;
        }
        else
        {
            turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }

    private void FixedUpdate()
    {
        if (push == true)
        {
            rb.AddForce(transform.up * pushSpeed);                 
        }

        if(moveLeft == true)
        {
            turnDirection = 1.0f;
            rb.AddTorque(turnDirection * turnSpeed);
        }

        if(moveRight==true)
        {
            turnDirection = -1.0f;
            rb.AddTorque(turnDirection * turnSpeed);
        }   
    }

    public void Shoot()
    {
        SoundManager.instance.PlaySound(bulletSound);
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Projectile(transform.up);
    }

    public void PushSpaceShip(bool pushShip)
    {
        push = pushShip;
    }

    public void TurnSpaceShipLeft(bool left)
    {
        moveLeft = left;
    }

    public void TurnSpaceShipRight(bool right)
    {
        moveRight = right;
           
    }
}
