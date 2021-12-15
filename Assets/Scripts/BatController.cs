using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{

    [Header("Movement")]
    public Transform[] waypoints;
    public float moveSpeed;
    private int waypointIndex;




    // Start is called before the first frame update
    void Start()
    {

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
}

