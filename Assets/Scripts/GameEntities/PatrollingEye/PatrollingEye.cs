using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrollingEye : MonoBehaviour
{
    public Transform waypointParent; // Assign in Inspector (Parent of all waypoints)
    public float moveSpeed = 3f;
    public float minWaitTime = 3f;
    public float maxWaitTime = 7f;

    private List<Transform> waypoints = new List<Transform>();
    private int lastWaypointIndex = -1;

    public bool isWaiting = false;
    private IEyeState currentState;
    public Light spotlight;

    private Transform currentTarget;

    private void Start()
    {
        if (waypointParent != null)
        {
            foreach (Transform child in waypointParent)
            {
                waypoints.Add(child);
            }
        }

        if (waypoints.Count == 0)
        {
            Debug.LogError("No waypoints found under the specified parent!");
            return;
        }

        SwitchState(new PatrollingState());
    }

    private void Update()
    {
        currentState?.UpdateState(this);

        // Move towards the current target
        if (currentTarget != null && !isWaiting)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        }

        // Keep spotlight pointing down
        if (spotlight != null)
        {
            spotlight.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }

    public void SwitchState(IEyeState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public Transform GetRandomWaypoint()
    {
        if (waypoints.Count < 2) return waypoints[0]; // Prevents infinite loop if only one exists

        int newWaypointIndex;
        do
        {
            newWaypointIndex = Random.Range(0, waypoints.Count);
        } while (newWaypointIndex == lastWaypointIndex); // Ensure it's not the same as the last one

        lastWaypointIndex = newWaypointIndex;
        return waypoints[newWaypointIndex];
    }

    public void SetDestination(Transform target)
    {
        currentTarget = target;
    }

    public bool HasReachedDestination()
    {
        return currentTarget != null && Vector3.Distance(transform.position, currentTarget.position) < 0.1f;
    }
}
