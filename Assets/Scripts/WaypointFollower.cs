using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2;
    // Update is called once per frame
    private void Update()
    {
        //Vector2.Distance method basically needs 2 variable which are the current waypoint position, and moving platform position
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1)
        {
            //basically currentWaypointIndex++ exists to increment, and move the platform.
            currentWaypointIndex++;
            //this is used to return the platform to its original position.
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //Time.deltaTime calculates time instead of framerate.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
