using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AdjudicatorAttackState : AdjudicatorState
{
    Health playerHealth;
    float damagePerSecond = 10f;
    public AdjudicatorAttackState(AdjudicatorController adjudicator) : base(adjudicator)
    {
        //Grab health component of player
        playerHealth = adjudicator.playerObject.GetComponent<Health>();
    }
    public override void OnStateEnter()
    {
        Debug.Log("Enemy in Attack State");
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy stopped attacking");
    }

    public override void OnStateUpdate()
    {
        Attack();
        adjudicator.supremeLaser.SetActive(true);
        if (adjudicator.player != null)
        {
            //Attack Player
            if (Vector3.Distance(adjudicator.transform.position, adjudicator.player.position) > adjudicator.attackRange)
            {
                //Go to Follow
                adjudicator.ChangeState(new AdjudicatorFollowState(adjudicator));
            }

            adjudicator.agent.destination = adjudicator.player.position;
        }
        else
        {
            //Go back to Idle
            adjudicator.ChangeState(new AdjudicatorIdleState(adjudicator));
        }
    }

    private void Attack()
    {
        if (playerHealth != null)
        {
            Debug.Log("Enemy is attacking");
            adjudicator.laser.enabled = true;
            adjudicator.laser.positionCount = 2;
            adjudicator.laser.SetPosition(0, adjudicator.laserEye.transform.position);
            adjudicator.laser.SetPosition(1, adjudicator.player.transform.position);
            playerHealth.DeductHealth(damagePerSecond * Time.deltaTime);
        }
    }
}
