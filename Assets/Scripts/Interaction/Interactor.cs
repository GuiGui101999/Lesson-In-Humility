using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactor : MonoBehaviour
{
    protected PlayerInput playerInput; //protected is an access modifier and that
    //field is only accessible by the base class (Interactor) and the ones that derive from it.

    private void Start()
    {
        playerInput = PlayerInput.GetInstance();
    }
    void Update()
    {
        Interact();
    }

    public abstract void Interact();
}
