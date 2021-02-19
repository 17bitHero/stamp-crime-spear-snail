using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float speed;
    public float speedDivisor;
    public float jumpForce;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Rigidbody2D rigidbody2D;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private bool is_on_ground;
    private int jumps;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float adjustedSpeed = speed / speedDivisor;
        float moveX = Input.GetAxis("Horizontal") * adjustedSpeed;

        if (is_on_ground)
        {
            transform.position += new Vector3(moveX, 0f, 0f);
        } else
        {
            transform.position += new Vector3((float)(moveX / 1.5), 0f, 0f);
        }
        if (Input.GetButtonDown("Jump") && (is_on_ground || jumps != 2))
        {
            Vector2 jumpF = new Vector2(0, jumpForce);
            rigidbody2D.AddForce(jumpF);
            jumps++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollisionIsWithGround(collision))
        {
            is_on_ground = true;
            jumps = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!CollisionIsWithGround(collision))
        {
            is_on_ground = false;
            if (jumps == 0 && jumps != 2)
            {
                jumps = 1;
            }
        }
    }
    private bool CollisionIsWithGround (Collision2D collision)
    {
        bool is_with_ground = false;
        foreach(ContactPoint2D c in collision.contacts)
        {
            Vector2 collision_direction_vector = c.point - rigidbody2D.position;
            if(collision_direction_vector.y < 0)
            {
                is_with_ground = true;
            }
        }
        return is_with_ground;
    }
}
