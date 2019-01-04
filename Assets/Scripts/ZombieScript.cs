using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour {
    public List<Transform> waypoints = new List<Transform>();
    // The waypoint currently targeted
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    // Define minimum distance of enemy from waypoint
    private float minDistance = 0.1f;
    private int lastWaypointIndex;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        // Start going to the first waypoint
        targetWaypoint = waypoints[targetWaypointIndex];
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetWaypoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && (agent.remainingDistance < minDistance))
            GotoNextPoint();
    }

    void UpdateTargetWayPoint()
    {
        targetWaypointIndex++;

        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (waypoints.Count == 0)
            return;

        UpdateTargetWayPoint();
        agent.destination = targetWaypoint.position;
    }
}
