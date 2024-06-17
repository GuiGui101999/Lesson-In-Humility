using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionProtocol : MonoBehaviour
{
    public Transform player;
    public Transform originTransform;
    public LineRenderer laser;
    Health playerHealth;
    float dPS = 10f;
    public bool isWrongPad = false;

    private void Start()
    {
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
        }
        laser.enabled = false;
    }
    private void Update()
    {
        ExecutionCondition();
    }
    public void ExecutionCondition()
    {
        if (player != null && isWrongPad)
        {
            Debug.Log("Execution Protocol Initiated");
            //Generate laser
            if (originTransform != null && laser != null)
            {
                laser.enabled = true;
                laser.positionCount = 2;
                laser.SetPosition(0, originTransform.position);
                laser.SetPosition(1, player.transform.position);
            }
            HeadLaserAttack();
        }
        else
        {
            laser.enabled = false;
        }
    }
    private void HeadLaserAttack()
    {
        if (playerHealth != null)
        {
            playerHealth.DeductHealth(dPS * Time.deltaTime);
        }
    }

    public void WrongPad()
    {
        isWrongPad = true;
    }

    public void RightPad()
    {
        isWrongPad = false;
    }
}
