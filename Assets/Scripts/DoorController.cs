/*
 * Program Header: Door Controller
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 15, 2021
 * Version 1.0
 * 
 * End Door object, Handles collision with player and changes sprite if 
 * all keys have been collected
 * 
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [Header("Door")]

    public Sprite unlockedDoor;
    public bool doorUnlocked;


    private PlayerController player;

    public bool levelComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.allKeysCollected)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = unlockedDoor;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && player.allKeysCollected)
        {
            levelComplete = true;
        }
    }
}
