using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public AudioClip explosionSound;

    public Sprite[] sprites;
    private SpriteRenderer sr;

    private Rigidbody2D rb;
    public GameObject explode;

    public float speed;
    public float maxLifetime;
    public float damage;

    GameManager gm;



    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        sr.sprite = sprites[Random.Range(0, sprites.Length)];
        transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360);
    }

    private void Update()
    {
        if (gm.isGameOver)
            Destroy(gameObject);
    }

    public void SetTrajectory(Vector2 direction)
    {
        rb.AddForce(direction * speed);
        Destroy(gameObject, maxLifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySound(explosionSound);

        if (collision.gameObject.name == "SpaceShip" || collision.gameObject.name == "Earth")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

        Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
