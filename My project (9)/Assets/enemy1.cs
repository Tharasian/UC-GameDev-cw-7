using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = -3f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed > 0)
        {
            gameObject.transform.localScale = new Vector2(-7, 7);
        }
        else if (speed < 0)
        {
            gameObject.transform.localScale = new Vector2(7, 7);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            speed = -speed;
        }
        if (collision.tag == "Bullet")
        {
            
        }
    }
}
