using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class CorrectOrientationCheck : MonoBehaviour
{
    [SerializeField] public Transform raycastOrigin;
    [SerializeField] public float rayDistance;
    public string targetTag = "ObjectDetection";
    private bool eventTriggered = false;

    public UnityEvent onCorrectCylinderOrientationAndPosition;

    private void Update()
    {
        if (raycastOrigin == null)
        {
            Debug.Log("Raycast origin transform is null");
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, transform.forward, out hit, rayDistance))
        {
            Debug.Log($"Ray hit: {hit.collider.name}");

            if (hit.collider.CompareTag(targetTag))
            {
                Debug.Log($"Ray hit {hit.collider.name}");
                if (!eventTriggered)
                onCorrectCylinderOrientationAndPosition.Invoke();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (raycastOrigin == null) { return; }

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}
