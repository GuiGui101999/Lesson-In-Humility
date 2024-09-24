using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Mathematics;
using UnityEngine;

public class Section3CorridorLasers : MonoBehaviour
{
    [SerializeField] public Transform[] laserGenerators;
    Health playerHealth;
    public float damageMultiplier = 20f;
    public LineRenderer[] laserRenderer;
    private bool isEnabled = true;
    public float laserMaxDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            GeneratorLasers();
        }
        else
        {
            foreach (LineRenderer renderer in laserRenderer)
            {
                renderer.enabled = false;
            }
        }
    }

    public void GeneratorLasers() //Method will get invoked when the previous level ends because isEnabled will be set to true.
    {
        if (isEnabled && laserGenerators != null)
        {
            for (int i = 0; i < laserGenerators.Length; i++)
            {
                LineRenderer renderer = laserRenderer[i];
                //Generate lasers
                if (Physics.Raycast(laserGenerators[i].position, laserGenerators[i].forward, out RaycastHit hit, laserMaxDistance))
                {
                    renderer.enabled = true;
                    renderer.positionCount = 2;
                    renderer.SetPosition(0, laserGenerators[i].position);
                    renderer.SetPosition(1, hit.point);

                    if (hit.collider.CompareTag("Player"))
                    {
                        Attack();
                    }
                }
                else
                {
                    renderer.enabled = false;
                    renderer.positionCount = 0;
                }
            }
        }
    }

    private void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.DeductHealth(damageMultiplier * Time.deltaTime);
        }
    }

    public void LasersActive()
    {
        isEnabled = true;
    }

    public void lasersInactive()
    {
        isEnabled = false;
    }
}
