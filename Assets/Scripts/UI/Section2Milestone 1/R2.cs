using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2 : MonoBehaviour, IReadableObjects
{
    [SerializeField] private GameObject bookUI;

    public void Start()
    {

    }
    public void OnHoverEnter()
    {
        Debug.Log("Book detected");
    }

    public void OnHoverExit()
    {
        Debug.Log("Book no longer detected");
        bookUI.SetActive(false);
    }

    public void OnRead()
    {
        if (this.gameObject != null)
        {
            bookUI.SetActive(true);
        }
    }
}
