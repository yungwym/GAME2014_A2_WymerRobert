/*
 * Program Header: Bat Controller
 * Robert Wymer - 101070567
 * Last Date Modified - Dec 15, 2021
 * Version 1.0
 * 
 * Controls movement of the Bat Enemy Object and Collision with player
 *
 * 
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    [Header("Movement")]
    public Transform[] waypoints;
    public float moveSpeed;
    private int waypointIndex;

    [Header("Enemy Variables")]
    public int rewardScore;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAlongPoints();
    }


    private void MoveAlongPoints()
    {
        Vector3 targetPos = waypoints[waypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            if (waypointIndex < waypoints.Length - 1)
            {
                waypointIndex++;
                Flip();
            }
            else
            {
                waypointIndex = 0;
                Flip();
            }
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.Play("EnemyDeath");
            other.gameObject.GetComponent<PlayerController>().AddToScore(rewardScore);
            Destroy(gameObject);
        }
    }
}

