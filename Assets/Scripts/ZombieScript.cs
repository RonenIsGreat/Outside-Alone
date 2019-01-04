using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour {
    public List<Transform> waypoints = new List<Transform>();
    public Transform player;
    public float distanceToSee = 10;

    // The waypoint currently targeted
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    // Define minimum distance of enemy from waypoint
    private float minDistance = 0.1f;
    private int lastWaypointIndex;
    private NavMeshAgent agent;
    private Animator zombieAnimator;
    private float walkSpeed;
    private float runSpeed;

    // Use this for initialization
    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        // Start going to the first waypoint
        targetWaypoint = waypoints[targetWaypointIndex];
        agent = GetComponent<NavMeshAgent>();
        agent.destination = targetWaypoint.position;
        zombieAnimator = GetComponent<Animator>();
        walkSpeed = agent.speed;
        runSpeed = walkSpeed * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= distanceToSee)
        {
            runToTarget(player);
        }
        else if (!agent.pathPending && (agent.remainingDistance < minDistance))
            GotoNextPoint();
    }

    void runToTarget(Transform target)
    {
        agent.speed = runSpeed;
        zombieAnimator.speed = runSpeed;
        agent.destination = target.position;
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
        agent.speed = walkSpeed;
        zombieAnimator.speed = walkSpeed;
        agent.destination = targetWaypoint.position;
    }
}
