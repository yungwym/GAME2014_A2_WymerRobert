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
            //other.transform.position = gameController.currentSpawnPoint.position;

            other.transform.position = spawnPoint.position; 
        }
        else
        {
           // other.gameObject.SetActive(false);
        }
    }
}
