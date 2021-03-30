using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public float dirAngle = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Gravity();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Gravity()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
            jumpForce = Math.Abs(jumpForce);
            dirAngle = 0;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Physics2D.gravity = new Vector2(0, 9.81f);
            jumpForce = -1 * Math.Abs(jumpForce);
            dirAngle = 180;
        }

        transform.rotation = Quaternion.AngleAxis(dirAngle, Vector3.left);
    }
}
