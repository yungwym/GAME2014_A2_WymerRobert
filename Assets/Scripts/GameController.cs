/*
 * Program Header: Game Controller
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 13, 2021
 * Version 1.0
 *
 * Handles Player Spawn Point 
 * 
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public Transform currentSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        player.position = currentSpawnPoint.position;
    }

    public void SetCurrentSpawnPoint(Transform newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }
}
