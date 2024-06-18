using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section3Entry : MonoBehaviour, IReadableObjects
{
    [SerializeField] private GameObject pageUI;

    public void Start()
    {

    }

    public void OnHoverEnter()
    {
        Debug.Log("Entry detected");
    }

    public void OnHoverExit()
    {
        Debug.Log("Entry no longer detected");
        pageUI.SetActive(false);
    }

    public void OnRead()
    {
        if (this.gameObject != null)
        {
            pageUI.SetActive(true);
        }
    }
}
