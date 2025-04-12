using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;
    public float followRange = 10f;
    public float pauseRange = 2f;
    
    private int currentWaypointIndex;
    private NavMeshAgent agent;
    private bool isPaused;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= followRange)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (!isPaused)
            {
                PatrolWaypoints();
            }
        }
    }

    private void PatrolWaypoints()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(PauseBeforeNextWaypoint());
        }
    }

    private IEnumerator PauseBeforeNextWaypoint()
    {
        isPaused = true;
        yield return new WaitForSeconds(pauseRange);
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        isPaused = false;
    }
}
