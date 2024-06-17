using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdjudicatorController : MonoBehaviour
{
    private AdjudicatorState currentState;
    public Transform[] targetPoints;
    [SerializeField] private Transform targetPointsParent;
    public GameObject playerObject;

    [Range(0f, 0.5f)]
    public float accuracy = 0.1f;

    [Range(0f, 5f)]
    public float waitTime = 1f;

    public bool isRandom = false;

    public Transform enemyEye;
    public Transform laserEye;

    [Range(0f, 2.0f)]
    public float checkRadius = 0.4f;
    public float playerDistance;

    [Range(2.2f, 15f)]
    public float followRange = 5f;

    [Range(0.2f, 3f)]
    public float attackRange = 2f;
    public float rayMaxDistance = 5f;

    public LineRenderer laser;

    [HideInInspector] public Transform player; //Hide public values from the inspector.

    public NavMeshAgent agent;

    public Color debugColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
        GetTargetPositions();
        currentState = new AdjudicatorIdleState(this); //reference to enemy controller.
        currentState.OnStateEnter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate();
    }

    public void ChangeState(AdjudicatorState state)
    {
        //Moving from previous state to new state
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    public void GetTargetPositions()
    {
        targetPoints = new Transform[targetPointsParent.childCount];
        Debug.Log(targetPointsParent.childCount);
        for (int i = 0; i < targetPointsParent.childCount; i++)
        {
            targetPoints[i] = targetPointsParent.GetChild(i);
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = debugColor;

        Gizmos.DrawWireSphere(enemyEye.position, checkRadius);
        Gizmos.DrawWireSphere(enemyEye.position + enemyEye.forward * playerDistance, checkRadius);
        Gizmos.DrawLine(enemyEye.position, enemyEye.position + enemyEye.forward * playerDistance);
    }
}
