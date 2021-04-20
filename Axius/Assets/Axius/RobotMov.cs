using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMov : MonoBehaviour
{
    float xCenter;
    public float patrolDistance = 1;
    public float movementSpeed = 1;
    public bool movRight = true;
    private bool following = false;
    private Transform player;
    SpriteRenderer sprite;
    void Start()
    {
        xCenter = this.transform.position.x;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    //TODO: Make the robots turn around after hitting a wall
    //      Fix the bug where robot movement is influenced by player movement
    //      Fix the bug with the robot growing after starting to chase the player

    void FixedUpdate()
    {
        //If the player is close enough, the robot will follow the player
        if(Vector2.Distance(this.transform.position, player.position) <= 6)
        {
            following = true;
            if (player.position.x > transform.position.x)
                movRight = true;
            //Robot moves towards the player at 2x speed
            transform.position = Vector2.MoveTowards(transform.position, player.position, movementSpeed * 2 * Time.deltaTime);
        }
        else
        {
            //if the robot has stopped following the player, its center position resets
            if(following)
            {
                xCenter = this.transform.position.x;
                following = false;
            } 
            //The robot patrols around its center point
            if (movRight)
                transform.Translate(Vector2.right * Time.deltaTime * movementSpeed); 
            else
                transform.Translate(Vector2.left * Time.deltaTime * movementSpeed);
            //If the robot gets too far away from its spawn point, it will turn around
            if (Mathf.Abs(this.transform.position.x - xCenter) >= patrolDistance)
                movRight = !movRight;
        }
        sprite.flipX = !movRight;
    }
    
}
