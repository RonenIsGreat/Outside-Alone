using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour {
    public List<Transform> waypoints = new List<Transform>();
    // The waypoint currently targeted
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    // Define minimum distance of enemy from waypoint
    private float minDistance = 0.1f;
    private int lastWaypointIndex;

    private float movementSpeed = 3.0f;
    private float rotationSpeed = 2.0f;

    // Use this for initialization
    void Start () {
        lastWaypointIndex = waypoints.Count - 1;
        // Start going to the first waypoint
        targetWaypoint = waypoints[targetWaypointIndex];
	}
	
	// Update is called once per frame
	void Update () {
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        // check the rotation needed in order to get to that direction to target
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation,rotationToTarget,rotationStep);

        // distance between enemt and target waypoint
        float distance = Vector3.Distance(transform.position,targetWaypoint.position);
        CheckDistanceToWayPoint(distance);
        // Move to next waypoint
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
	}

    void CheckDistanceToWayPoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWayPoint();
        }
    }

    void UpdateTargetWayPoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
