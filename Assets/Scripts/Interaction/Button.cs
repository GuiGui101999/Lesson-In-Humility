using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour, ISelect
{
    [SerializeField] private Renderer buttonRenderer;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color hoverColor;

    public UnityEvent OnPushButton;

    public void OnHoverEnter()
    {
        buttonRenderer.material.color = hoverColor;
    }

    public void OnHoverExit()
    {
        buttonRenderer.material.color = defaultColor;
    }

    public void OnSelect()
    {
        Debug.Log("Button Pushed");
        OnPushButton?.Invoke(); //Would not call function if OnPushButton doesn't have any functions registered or subscribed to it.
    }

    // Start is called before the first frame update
    void Start()
    {
        if (buttonRenderer != null)
        {
            defaultColor = buttonRenderer.material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
