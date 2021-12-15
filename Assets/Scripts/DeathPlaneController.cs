/*
 * Program Header: Death Plane Controller
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 13, 2021
 * Version 1.0
 * 
 * 
 * Handles Collision with player and death plane, resets players positon if collides
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    private GameController gameController;

    public Transform spawnPoint;

    private void Start()
    {
       // gameController = GameObject.FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.position; 
        }
    }
}
