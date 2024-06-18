using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M3C : MonoBehaviour, IReadableObjects
{
    [SerializeField] private GameObject muralUI;

    public void Start()
    {

    }

    public void OnHoverEnter()
    {
        Debug.Log("Mural detected");
    }

    public void OnHoverExit()
    {
        Debug.Log("Mural no longer detected");
        this.muralUI.SetActive(false);
    }

    public void OnRead()
    {
        if (this.gameObject != null)
        {
            muralUI.SetActive(true);
        }
    }
}
