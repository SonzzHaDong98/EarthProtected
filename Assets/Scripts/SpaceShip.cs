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
        if (pushSpaceShip)
        {
            PushSpaceShip();        
        }
        if(turnDirection != 0)
        {
            rb.AddTorque(turnDirection * turnSpeed);
        }

        TurnSpaceShipLeft(); 
        TurnSpaceShipRight();
    }

    public void Shoot()
    {
        SoundManager.instance.PlaySound(bulletSound);
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Projectile(transform.up);
    }

    public void PushSpaceShip()
    {
        rb.AddForce(transform.up * pushSpeed);
    }

    public void TurnSpaceShipLeft()
    {
        turnDirection = 1.0f;
        rb.AddTorque(turnDirection * turnSpeed);
        
    }

    public void TurnSpaceShipRight()
    {
        turnDirection = -1.0f;
        rb.AddTorque(turnDirection * turnSpeed);            
    }
}
