using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnim;

    private float timer = 0;

    [SerializeField] private Renderer doorRenderer; //regardless of renderer used, it would still be able to get access to the renderer class.
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color activeColor;
    [SerializeField] private float waitTime = 1.0f;

    private bool isLocked = true;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
        if (doorRenderer != null)
        {
            defaultColor = doorRenderer.material.color;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isLocked && other.CompareTag("Player"))
        {
            timer = 0;
            doorRenderer.material.color = activeColor;
            //doorAnim.SetBool("isDoorOpen", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isLocked) { return; } //Guard clause to prevent from carrying out method.
        if (!other.CompareTag("Player")) //Guard clause to exit if not player.
        {
            return;
        }

        timer += Time.deltaTime; //increasing value of timer every frame (value of 1 per second)
        if (timer >= waitTime)
        {
            timer = waitTime; //the waitTime would now start again from beginning when it is equal to timer.
            doorAnim.SetBool("isDoorOpen", true);
            //waitTime *= 1.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("isDoorOpen", false);
            doorRenderer.material.color = defaultColor;
        }
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
