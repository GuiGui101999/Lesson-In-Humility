using UnityEngine;

public class PatrollingState : IEyeState
{
    private Transform targetWaypoint;

    public void EnterState(PatrollingEye eye)
    {
        eye.isWaiting = false;
        targetWaypoint = eye.GetRandomWaypoint();
        eye.SetDestination(targetWaypoint);
    }

    public void UpdateState(PatrollingEye eye)
    {
        if (eye.isWaiting || targetWaypoint == null) return;

        if (eye.HasReachedDestination())
        {
            eye.SwitchState(new WaitingState());
        }
    }
}
