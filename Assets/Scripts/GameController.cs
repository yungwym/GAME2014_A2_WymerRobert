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
