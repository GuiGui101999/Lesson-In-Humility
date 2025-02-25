using System.Collections;
using UnityEngine;

public class WaitingState : IEyeState
{
    public void EnterState(PatrollingEye eye)
    {
        eye.StartCoroutine(WaitCoroutine(eye));
    }

    private static IEnumerator WaitCoroutine(PatrollingEye eye)
    {
        eye.isWaiting = true;
        float waitTime = Random.Range(eye.minWaitTime, eye.maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        eye.SwitchState(new PatrollingState());
    }

    public void UpdateState(PatrollingEye eye)
    {
        // Nothing needed here since coroutine handles waiting
    }
}

