using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjudicatorIdleState : AdjudicatorState
{
    private int currentTarget = 0;

    private float timer;

    public AdjudicatorIdleState(AdjudicatorController adjudicator) : base(adjudicator) //Inheriting properties of the EnemyState contructor and passing in enemy. Base refers to class we're inheriting from. Anytime we construct new enemy idles state, this will be called.
    {

    }
    public override void OnStateEnter() //Need concrete state to have reference to agent and things that exist across multiple states
    {
        adjudicator.agent.destination = adjudicator.targetPoints[currentTarget].position;
        timer = adjudicator.waitTime;
        adjudicator.debugColor = Color.blue;
        Debug.Log("Enemy entered Idle");
    }

    public override void OnStateExit()
    {
        Debug.Log("Enemy is no longer Idle");
    }

    public override void OnStateUpdate()
    {
        Debug.Log("Entered Idle Update");
        PatrolAtPosition();
        adjudicator.supremeLaser.SetActive(false);
        if (Physics.SphereCast(adjudicator.enemyEye.position, adjudicator.checkRadius, adjudicator.transform.forward, out RaycastHit hit, adjudicator.playerDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("Found Player");

                adjudicator.player = hit.transform;
                adjudicator.agent.destination = adjudicator.player.position;

                //Switch to new state
                adjudicator.ChangeState(new AdjudicatorFollowState(adjudicator));
            }
        }
    }

    private void PatrolAtPosition() //Set Coroutine and passing a timer for each position
    {
        if (adjudicator.agent.remainingDistance < adjudicator.accuracy) //Checking distance between enemy and target position.
        {
            SetNewTargetPosition();

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                //Set new enemy position
                adjudicator.agent.destination = adjudicator.targetPoints[currentTarget].position;
                timer = adjudicator.waitTime;
            }
        }

    }

    private void SetNewTargetPosition()
    {
        if (adjudicator.isRandom)
        {
            Debug.Log("Randomising positions");
            int randomInt = -1; //Set to -1 at first because can have a value of 0, so you don't want to use a value of -1.
            do
            {
                randomInt = Random.Range(0, adjudicator.targetPoints.Length); //Constantly do this while random int is the same as current target to avoid same current Target value as the previous one.
            } while (randomInt == currentTarget);

            currentTarget = randomInt;
        }
        else
        {
            currentTarget++; //increment operand adds 1 to the x value everytime.
            if (currentTarget >= adjudicator.targetPoints.Length) //Ensuring the current Target does not exceed the number of target points
            {
                currentTarget = 0;
            }
        }
    }
}
