using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D collider22D;
    public float jumpforce;
    public int speed;
    bool isGrounded;
    float horizontalinput;
    int bulletspeed=3;
    public GameObject bullet;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider22D = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalinput*speed, rb.velocity.y);
        if (horizontalinput > 0)
        {
            transform.localScale = new Vector3(7, 7, 1);
            anim.SetBool("Running", true);

        }
        else if (horizontalinput < 0)
        {
            transform.localScale = new Vector3(-7, 7, 1);
            anim.SetBool("Running", true);
        }
        else
            anim.SetBool("Running", false);
        if (Input.GetKey(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        anim.SetBool("Grounded", false);
        shootbullet();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Grounded", true);

        }
    }
    void shootbullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
            if (horizontalinput > 0)
            {
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed, 0);
            }
            else
            {
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletspeed, 0);
            }

            Destroy(bulletClone, 3);
        }
    }
}
