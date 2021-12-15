/*
 * Program Header: Moving Platform Controller 
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 13, 2021
 * Version 1.0
 * 
 * Controls moving Platform
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [Header("Movement")]
    public MovingPlatformDirection direction;
    [Range(0.1f, 10.0f)]
    public float speed;
    [Range(1, 20)]
    public float distance;
    [Range(0.05f, 0.1f)]
    public float distanceOffset;
    public bool isLooping;

    private Vector2 startingPosition;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        if (isLooping)
        {
            isMoving = true;
        }
    }

    private void MovePlatform()
    {
        float pingPongValue = (isMoving) ? Mathf.PingPong(Time.time * speed, distance) : distance;

        if ((!isLooping) && (pingPongValue >= distance - distanceOffset))
        {
            isMoving = false;
        }

        switch (direction)
        {
            case MovingPlatformDirection.HORIZONTAL:
                transform.position = new Vector2(startingPosition.x + pingPongValue, transform.position.y);
                break;
            case MovingPlatformDirection.VERTICAL:
                transform.position = new Vector2(transform.position.x, startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_UP:
                transform.position = new Vector2(startingPosition.x + pingPongValue, startingPosition.y + pingPongValue);
                break;
            case MovingPlatformDirection.DIAGONAL_DOWN:
                transform.position = new Vector2(startingPosition.x + pingPongValue, startingPosition.y - pingPongValue);
                break;
        }
    }
}
