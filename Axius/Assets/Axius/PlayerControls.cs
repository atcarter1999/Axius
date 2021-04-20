using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControls : MonoBehaviour
{
	AudioSource jumpSound;
	public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public float dirAngle = 0;
    private bool facingRight;
	private bool right = false;
	private bool left = false;
	private bool up = false;
	private bool down = true;
	enum GravityDirection { Down, Left, Up, Right };
	 GravityDirection m_GravityDirection;
    // Start is called before the first frame update
    void Start()
    {
		m_GravityDirection = GravityDirection.Down;
		jumpSound = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		
		Vector3 movement = new Vector3(0f,0f,0f);
		if (Input.GetKeyDown(KeyCode.J))
		{
			m_GravityDirection = GravityDirection.Left;
			if (left == false)
			{
				if(right == true)
				{
					transform.Rotate(new Vector3(0, 0, -180.0f));
				}
				if(up == true)
				{
					transform.Rotate(new Vector3(0, 0, -270.0f));
				}
				if(down == true)
				{
					transform.Rotate(new Vector3(0, 0, -90.0f));
				}
				left = true;
				right = false;
				up = false;
				down = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.I))
		{
			m_GravityDirection = GravityDirection.Up;
			if (up == false)
			{
				if (right == true)
				{
					transform.Rotate(new Vector3(0, 0, 90.0f));
				}
				if (left == true)
				{
					transform.Rotate(new Vector3(0, 0, 270.0f));
				}
				if (down == true)
				{
					transform.Rotate(new Vector3(0, 0, 180.0f));
				}
				//transform.Rotate(new Vector3(0, 0, -90.0f));
				left = false;
				right = false;
				up = true;
				down = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.L))
		{
			
			m_GravityDirection = GravityDirection.Right;
			if (right == false)
			{
				if (left == true)
				{
					transform.Rotate(new Vector3(0, 0, 180.0f));
				}
				if (up == true)
				{
					transform.Rotate(new Vector3(0, 0, -90.0f));
				}
				if (down == true)
				{
					transform.Rotate(new Vector3(0, 0, 90.0f));
				}
				left = false;
				right = true;
				up = false;
				down = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			m_GravityDirection = GravityDirection.Down;
			if (down == false)
			{
				if (right == true)
				{
					transform.Rotate(new Vector3(0, 0, -90.0f));
				}
				if (up == true)
				{
					transform.Rotate(new Vector3(0, 0, -180.0f));
				}
				if (left == true)
				{
					transform.Rotate(new Vector3(0, 0, 90.0f));
				}

				left = false;
				right = false;
				up = false;
				down = true;
			}
		}
		
        Jump();
		
		if (m_GravityDirection == GravityDirection.Left)
		{
		movement = new Vector3(0f, Input.GetAxis("Horizontal") * -1f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
		}
		if (m_GravityDirection == GravityDirection.Right)
		{
		movement = new Vector3(0f, Input.GetAxis("Horizontal"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
		}
		if (m_GravityDirection == GravityDirection.Up)
		{
		movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
		}
		if (m_GravityDirection == GravityDirection.Down)
		{
		movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
		}
		
        gameObject.GetComponent<Animator>().SetFloat("playerSpeed", movement.magnitude);
        if(movement.magnitude > 0)
        {
            if (movement.x > 0)
                facingRight = true;
            else
                facingRight = false;
        }
        
        gameObject.GetComponent<SpriteRenderer>().flipX = facingRight;
        gameObject.GetComponent<Animator>().SetBool("playerIsJumping", false);
    }

    void Jump()
    {
		jumpSound.Play();
		if (m_GravityDirection == GravityDirection.Left)
		{
			if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForce, 0f), ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("playerIsJumping", true);
        }
		}
		if (m_GravityDirection == GravityDirection.Right)
		{
			if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForce * -1f, 0f), ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("playerIsJumping", true);
        }
		}
		if (m_GravityDirection == GravityDirection.Up)
		{
			if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce * -1f), ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("playerIsJumping", true);
        }
		}
		if (m_GravityDirection == GravityDirection.Down)
		{
			if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("playerIsJumping", true);
        }
		}
        
    }

}
