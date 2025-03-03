using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private float checkRadius;

    public UnityEvent OnCubePlaced;
    public UnityEvent OnCubeRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OrbOfAbsolution"))
        {
            OnCubePlaced?.Invoke();
        }
        //Check if cube is closer to the middle
        //Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, pickupLayerMask);

        //Debug.Log(colliders.Length);

        //foreach (Collider collider in colliders)
        //{
        //Debug.Log(collider.gameObject.name);
        //Unlock door if there is at least one cube overlapping the sphere

        //if (collision.gameObject.CompareTag("OrbOfAbsolution"))
            //{
                //OnCubePlaced?.Invoke(); //If there are no functions that are subscribed to the OnCubePlaced, then it will not be invoked.
                //break; //Break out of the for loop.
            //}
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("OrbOfAbsolution"))
        {
            OnCubeRemoved?.Invoke();
        }
    }
}
