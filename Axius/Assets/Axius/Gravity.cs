using UnityEngine;

public class Gravity : MonoBehaviour
{
    enum GravityDirection { Down, Left, Up, Right };
    GravityDirection m_GravityDirection;

    void Start()
    {
        m_GravityDirection = GravityDirection.Down;
    }

    void FixedUpdate()
    {
		
		if (Input.GetKeyDown(KeyCode.J))
		{
			m_GravityDirection = GravityDirection.Left;
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			m_GravityDirection = GravityDirection.Up;
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			m_GravityDirection = GravityDirection.Right;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			m_GravityDirection = GravityDirection.Down;
		}
		
        switch (m_GravityDirection)
        {
            case GravityDirection.Down:
                //Change the gravity to be in a downward direction (default)
                Physics2D.gravity = new Vector2(0, -9.8f);
                break;

            case GravityDirection.Left:
                //Change the gravity to go to the left
                Physics2D.gravity = new Vector2(-9.8f, 0);
                break;

            case GravityDirection.Up:
                //Change the gravity to be in a upward direction
                Physics2D.gravity = new Vector2(0, 9.8f);
                break;

            case GravityDirection.Right:
                //Change the gravity to go in the right direction
                Physics2D.gravity = new Vector2(9.8f, 0);
                break;
        }
    }
}