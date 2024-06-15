using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : Interactor
{
    [Header("Player Turn")]
    [SerializeField] private float turnSpeed = 10.0f; //For rotation of the head

    public override void Interact()
    {
        //Player turn movement
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * playerInput.mouseX); //Vector up and down refers to the X axis.
    }
}
