using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{
    public float maxSpeed;
    public bool grounded;
    public float jumpForce;
    public Rigidbody2D rb;
    bool facRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moving();
    }

    void moving()
    {
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if(move > 0 &&!facRight)
        {
            Flip();
        }
        else if(move < 0 &&facRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded == true)
            {
                rb.velocity = new Vector2(0, jumpForce);
            }          
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.transform.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "Ground")
        {
            grounded = false;
        }
    }

    void Flip()
    {
        facRight = !facRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
