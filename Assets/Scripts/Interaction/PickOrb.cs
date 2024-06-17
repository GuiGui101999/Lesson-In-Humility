using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOrb : MonoBehaviour, IPick
{
    FixedJoint joint;
    Rigidbody orbRb;
    [SerializeField] private GameObject orbOfAbsolution;
    [SerializeField] public GameObject someGameObject;
    [SerializeField] public float enableDuration = 3f;

    private void Start()
    {
        someGameObject.SetActive(false);
        orbRb = GetComponent<Rigidbody>();
    }

    public void OnDropped()
    {
        orbRb.isKinematic = false;
        orbRb.useGravity = true;
        transform.SetParent(null);
    }

    public void OnPicked(Transform attachTransform)
    {

        //Pickup item
        transform.position = attachTransform.position; //Pass in transform of player and make it the same as the position of object to show it was picked up.
        transform.rotation = attachTransform.rotation;
        transform.SetParent(attachTransform);

        orbRb.isKinematic = true; //Doesn't fall under the influence of physics while object is selected by player.
        orbRb.useGravity = false;
    }

    public void PlacedOnCorrectPad()
    {
        Debug.Log("This Orb has been destroyed");
        StartCoroutine(EnableAndDisableGameObject());
    }

    private IEnumerator EnableAndDisableGameObject()
    {
        someGameObject.SetActive(true);
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(enableDuration);
        Debug.Log("Coroutine ended");
        someGameObject.SetActive(false);
        Destroy(orbOfAbsolution);
        orbOfAbsolution = null;
    }
}
