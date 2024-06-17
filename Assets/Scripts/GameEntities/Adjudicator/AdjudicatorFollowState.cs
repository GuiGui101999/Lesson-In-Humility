using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjudicatorFollowState : AdjudicatorState
{
    public AdjudicatorFollowState(AdjudicatorController adjudicator) : base(adjudicator)
    {

    }

    public override void OnStateEnter()
    {
        adjudicator.debugColor = Color.red;
        Debug.Log("Enemy entered Follow State");
        adjudicator.laser.enabled = false;
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy stopped following Player");
    }

    public override void OnStateUpdate()
    {
        if (adjudicator.player != null)
        {
            if (Vector3.Distance(adjudicator.transform.position, adjudicator.player.position) > adjudicator.followRange)
            {
                //Go back to Idle
                adjudicator.ChangeState(new AdjudicatorIdleState(adjudicator));
            }

            //Attack Player
            if (Vector3.Distance(adjudicator.transform.position, adjudicator.player.position) < adjudicator.attackRange)
            {
                //Go to Attack
                adjudicator.ChangeState(new AdjudicatorAttackState(adjudicator));
            }

            adjudicator.agent.destination = adjudicator.player.position;
        }
        else
        {
            adjudicator.ChangeState(new AdjudicatorIdleState(adjudicator));
        }
    }
}
