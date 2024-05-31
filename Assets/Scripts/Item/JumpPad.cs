using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class JumpZone : MonoBehaviour
    {
        [SerializeField] float jumpForce = 400f, speed = 5f, jumpZoneForce = 50f;
        int jumpCount = 1;
        float moveX;

        bool isGround = false;
        bool isJumpZone = false;
        Rigidbody rb;

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Ground")
            {
                isGround = true;
                jumpCount = 1;
            }
            if (col.gameObject.tag == "JumpZone")
            {
                isJumpZone = true;
            }
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            jumpCount = 0;
        }

        void Update()
        {
            Movement();
        }

        void Movement()
        {
            if (isGround)
            {
                if (jumpCount > 0)
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        rb.AddForce(Vector2.up * jumpForce);
                        jumpCount--;
                    }
                }

                if (isJumpZone)
                {
                    rb.AddForce(new Vector2(0, jumpZoneForce) * jumpForce);
                    isJumpZone = false;
                }
            }

            moveX = Input.GetAxis("Horizontal") * speed;
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }
    }