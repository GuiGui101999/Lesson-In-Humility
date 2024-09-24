using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class SupremeLaser : MonoBehaviour
{
    public Transform player;
    public Transform originTransform;
    public GameObject orbAreaUI;
    public LineRenderer laser;
    Health playerHealth;
    float dPS = 10f;
    public bool playerEnter = false;
    public bool orbActive = true;

    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
        }
        laser.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ExecutionCondition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (orbActive == true)
        {
            if (other.CompareTag("Player"))
            {
                PlayerEntered();
                StartCoroutine(OrbAreaEnterUI());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLeft();
        }
    }

    public void ExecutionCondition()
    {
        if (player != null && playerEnter)
        {
            Debug.Log("Supreme Laser Protocol Initiated");
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

    private IEnumerator OrbAreaEnterUI()
    {
        orbAreaUI.SetActive(true);
        yield return new WaitForSeconds(5f);
        orbAreaUI.SetActive(false);
    }

    public void PlayerEntered()
    {
        playerEnter = true;
    }

    public void PlayerLeft()
    {
        playerEnter = false;
    }

    public void DisableSupremeLaser()
    {
        orbActive = false;
    }
}
