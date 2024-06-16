using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOrb : MonoBehaviour, IPick
{
    FixedJoint joint;
    Rigidbody orbRb;

    private void Start()
    {
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
}
