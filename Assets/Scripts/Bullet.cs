using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed;
    public float maxLifetime;
    private Rigidbody2D rb;
    GameManager gm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    public void Projectile(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Meteorite")
        {
            gm.ScoreUp();
        }
        Destroy(gameObject);
    }
}
